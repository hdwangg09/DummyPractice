using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PracticeDummy_WebClient.Models;
using System.Net.Http.Headers;

namespace PracticeDummy_WebClient.Controllers
{
    public class DummyController : Controller
    {
        private HttpClient _httpClient;
        private String endPointURL = string.Empty;
        public DummyController()
        {
            _httpClient = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            endPointURL = "http://localhost:5243";
        }
        
        [HttpGet]
        [Route("dummy")]
        public async Task<IActionResult> Index(string? dummyName, string? masterID)
        {
            HttpResponseMessage masterRes = await _httpClient.GetAsync($"{endPointURL}/master");
            HttpResponseMessage dummyRes = await _httpClient.GetAsync($"{endPointURL}/dummy/search?dummyName={dummyName}&masterID={masterID}");
             if (masterRes.IsSuccessStatusCode)
            {
                string responseData = await masterRes.Content.ReadAsStringAsync();
                List<DummyMaster> masters = JsonConvert.DeserializeObject<List<DummyMaster>>(responseData);
                ViewData["masters"] = masters;
            }
            if (dummyRes.IsSuccessStatusCode)
            {
                string responseData = await dummyRes.Content.ReadAsStringAsync();
                dynamic listDummy = JsonConvert.DeserializeObject<dynamic>(responseData);
                ViewData["listDummy"] = listDummy;
                return View();
            }
            else
            {
                return View("Error");
            }
        }
    }
}
