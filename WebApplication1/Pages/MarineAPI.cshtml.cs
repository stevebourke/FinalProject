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
        private readonly IHttpClientFactory _clientFactory;

        public MarineAPIModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }


        //The RootObject from the Post class - it will be filled below with the data coming in via the json

        public string Name { get; set; }

        public List<Rootobject> Rootobject { get; set; }




        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }


        //Tha name of the city which was posted is fed into the address, along with
        //the key we were given from openweathermap, and a call for metric values

        public async Task<IActionResult> OnPostAsync(string name)
        {

            var client = _clientFactory.CreateClient();

            try
            {
                client.BaseAddress = new Uri("https://magicseaweed.com/api/");
                HttpResponseMessage response = await client.GetAsync($"3520cfbae15bc809791873a0089e10bd/forecast/?spot_id=" + name);
                response.EnsureSuccessStatusCode();

                var stringResult = await response.Content.ReadAsStringAsync();
                List<Rootobject>Rootobject  = JsonConvert.DeserializeObject<List<Rootobject>>(stringResult);
                return Page();
            }
            catch (HttpRequestException httpRequestException)
            {
                return BadRequest($"Error getting data from openweathermap.org {httpRequestException.Message}");
            }


        }
    }
}