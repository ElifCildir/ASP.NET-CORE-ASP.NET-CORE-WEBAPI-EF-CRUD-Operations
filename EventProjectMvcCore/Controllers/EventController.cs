using EventProjectMvcCore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace EventProjectMvcCore.Controllers
{
    public class EventController : Controller
    {

        public IActionResult Index()

        {

            HttpClient client = new HttpClient();
            var response = client.GetAsync("https://localhost:44310/api/event").Result;
            List<Event> events;
            events = JsonConvert.DeserializeObject<List<Event>>(response.Content.ReadAsStringAsync().Result);

            return View(events);


        }

        [HttpGet]
        public IActionResult Create()
        {


            return View(new Event());

        }






        [HttpPost]
        public IActionResult Create(Event @event)
        {
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(@event), System.Text.Encoding.UTF8, "application/json");


            var response = httpClient.PostAsync("https://localhost:44310/api/event", content).Result;

            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync($"https://localhost:44310/api/event/{id}").Result;

            var events = JsonConvert.DeserializeObject<Event>(response.Content.ReadAsStringAsync().Result);

            return View(events);



        }


        [HttpPost]
        public IActionResult Edit(Event @event)
        {

            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(@event), System.Text.Encoding.UTF8, "application/json");

            var response = httpClient.PutAsync($"https://localhost:44310/api/event/{@event.EventID}", content).Result;


            return RedirectToAction("Index");



        }


        public IActionResult Delete(int id)
        {
            HttpClient httpHttpClient = new HttpClient();
            var response = httpHttpClient.DeleteAsync($"https://localhost:44310/api/event/{id}").Result;
            return RedirectToAction("Index");


        }








    }
}
