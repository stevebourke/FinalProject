using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using SurfProject.Model;

namespace SurfProject.Pages
{
    public class MarineAPIModel : PageModel
    {


        //Add in our dependency injection
        private readonly IHttpClientFactory _clientFactory;


        //Link to the database again
        private readonly MemberDetailsContext _db;


        public MarineAPIModel(IHttpClientFactory clientFactory, MemberDetailsContext db)
        {
            _clientFactory = clientFactory;

            _db = db;
        }


        //The RootObject (the surf forecast) - it will be filled below with the json from our api call
        public RootObject RootObject { get; set; }


        //This will hold our 'json string' after it is stringified
        public string StringResult { get; set; }


        [BindProperty]
        public SurfProfile SurfProfile { get; set; }



        [BindProperty]
        public Message Message { get; set; }



        [BindProperty]
        public Member Member { get; set; }



        //This will be used to hold all messages sent to the current user
        public List<Message> MyMessages { get; set; }


        
        //We need a list to store all of the forecasts that are sent back in a json array
        public List<RootObject> RootObjectList { get; set; }



        //This list will be used to hold the surf forecasts which match the criteria of a given surf profile
        public List<RootObject> FilteredList { get; set; }


    
        //List of other members' surf profiles which are a match for conditions over the next 24 hours
        //Using a dictionary to link each profile to the timestamp of the forecast it matches
        public Dictionary<int, List<SurfProfile>> PeersDictionary { get; set; } = new Dictionary<int, List<SurfProfile>>();


        //This will hold the length of longest list in dictionary - filled below
        public int MembersList { get; set; }


        //A list which will hold each distinct memberID from peers dictionary
        public List<int> DistinctMemberIDs { get; set; }


        //A list of all members in the database - used to set up a messsaging function
        public List<Member> AllMembers { get; set; }



        //On page loading...
        public async Task<IActionResult> OnGetAsync(int id)
        {
            //Use the surfprofile ID which was passed in to retrieve the relevant surf profile from the database
            SurfProfile = await _db.SurfProfiles.FindAsync(id);


            //This creates a list of all messages sent to this particular member
            MyMessages = _db.Messages.Where(x => x.RecipientID == SurfProfile.MemberID)
                .Select(x => x).ToList();



            //This is ok here since I am only dealing with two locations - it could perhaps be moved
            //to the SurfProfile class if there were more locations being used.
            //API call takes in an int id for each location - convert from a location to its corresponding spot id
            int loc = 1482;

            if (SurfProfile.Location == "Inch")
            { loc = 1482; }

            if (SurfProfile.Location == "Rossbeigh")
            { loc = 1483; }



            Member member = await _db.Members.FindAsync(SurfProfile.MemberID);


            //Get all the members in the database, but exclude the current member
            AllMembers = _db.Members.Where(x => x.MemberID != SurfProfile.MemberID)
                .Select(x => x).ToList();


            //Connect to the magicseaweed website from which we will get 
            //our json forecast data passing our API key and the location ID
            var client = _clientFactory.CreateClient();

            try
            {
                client.BaseAddress = new Uri("https://magicseaweed.com/api/");
                HttpResponseMessage response = await client.GetAsync($"3520cfbae15bc809791873a0089e10bd/forecast/?spot_id=" + loc);
                response.EnsureSuccessStatusCode();


                //Convert the incoming json into a list of root objects(forecasts)
                var StringResult = await response.Content.ReadAsStringAsync();
                RootObjectList = JsonConvert.DeserializeObject<List<RootObject>>(StringResult);


                //Check the rootobject list for matches of conditions with other members
                PeersDictionary = SurfProfile.GetPeersList(RootObjectList);


                //Found this on stackoverflow - get the length of the longest list of surf profiles in the dictionary
                if (PeersDictionary.Count > 0)
                { MembersList = PeersDictionary.Max(m => m.Value.Count); }


                //Get the Member IDs of the Surf Profiles in the Peers Dictionary
                DistinctMemberIDs = SurfProfile.GetPeerMemberIDs(PeersDictionary);



                //Get list of forecasts which match the surf profile conditions
                FilteredList = SurfProfile.GetFilteredList(RootObjectList);


                //If no upcoming forecast meets our criteria display a message
                if (FilteredList.Count() == 0)
                {

                    TempData["Message"] = "No upcoming forecasts match your criteria";
                    return Page();
                }



                return Page();
            }

        
            //If there is an error...
            catch (HttpRequestException httpRequestException)
            {
                return BadRequest($"Error getting data from magicseaweed.com {httpRequestException.Message}");
            }



        }
    }
}