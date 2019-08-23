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


        //Add in our dependency injections
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



        //We need a list to store all of the forecasts that are sent back in a json array
        public List<RootObject> RootObjectList { get; set; }


        public async Task<IActionResult> OnGetAsync(int id)
        {
            //Use the surfprofile ID which was passed in to retrieve the relevant surf profile from the database
            SurfProfile = await _db.SurfProfiles.FindAsync(id);


            //This is ok here since I am only dealing with two locations - it could perhaps be moved
            //to the SurfProfile class if there were more locations being used.
            //API call takes in an int id for each location - convert from a location to its corresponding spot id
            int loc = 1482;

            if (SurfProfile.Location == "Inch")
            { loc = 1482; }

            if (SurfProfile.Location == "Rossbeigh")
            { loc = 1483; }


            //Connect to the magicseaweed website from which we will get our json forecast data
            var client = _clientFactory.CreateClient();

            try
            {
                client.BaseAddress = new Uri("https://magicseaweed.com/api/");
                HttpResponseMessage response = await client.GetAsync($"3520cfbae15bc809791873a0089e10bd/forecast/?spot_id=" + loc);
                response.EnsureSuccessStatusCode();


                var StringResult = await response.Content.ReadAsStringAsync();
                RootObjectList = JsonConvert.DeserializeObject<List<RootObject>>(StringResult);


                return Page();



            }
            catch (HttpRequestException httpRequestException)
            {
                return BadRequest($"Error getting data from magicseaweed.com {httpRequestException.Message}");
            }

          

        }
    }
}