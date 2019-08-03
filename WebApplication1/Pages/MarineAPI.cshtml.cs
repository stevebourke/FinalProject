using System;
using System.Collections.Generic;
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


        private readonly MemberDetailsContext _db;


        public MarineAPIModel(IHttpClientFactory clientFactory, MemberDetailsContext db)
        {
            _clientFactory = clientFactory;

            _db = db;
        }




        //The RootObject from the Post class - it will be filled below with the data coming in via the json


        public string Name { get; set; }


        public string StringResult { get; set; }


        public List<RootObject> RootObjectList = new List<RootObject>();


        public RootObject RootObject { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }



        //Tha name of the location which was posted is fed into the address, along with
        //the key we were given from magicseaweed

        public async Task<IActionResult> OnPostAsync(string name)
        {



        var client = _clientFactory.CreateClient();

            try
            {
                client.BaseAddress = new Uri("https://magicseaweed.com/api/");
                HttpResponseMessage response = await client.GetAsync($"3520cfbae15bc809791873a0089e10bd/forecast/?spot_id=" + name);
                response.EnsureSuccessStatusCode();

                StringResult = await response.Content.ReadAsStringAsync();
                RootObjectList  = JsonConvert.DeserializeObject<List<RootObject>>(StringResult);
                return Page();


            }
            catch (HttpRequestException httpRequestException)
            {
                return BadRequest($"Error getting data from magicseaweed.com {httpRequestException.Message}");
            }

            _db.RootObjects.Add(RootObjectList[0]);
            await _db.SaveChangesAsync();

        }
    }
}