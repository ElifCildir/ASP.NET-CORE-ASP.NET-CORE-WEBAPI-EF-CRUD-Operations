using EventProjectMvcCore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace EventProjectMvcCore.Controllers
{
    public class CoachController : Controller
    {
        public IActionResult Index()

        {

            HttpClient client = new HttpClient();
            var response = client.GetAsync("https://localhost:44310/api/coach").Result;
            List<Coach> coaches;
            coaches = JsonConvert.DeserializeObject<List<Coach>>(response.Content.ReadAsStringAsync().Result);

            return View(coaches);


        }

        [HttpGet]
        public IActionResult Create()
        {


            return View(new Coach());

        }






        [HttpPost]
        public IActionResult Create(Coach coach)
        {
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(coach), System.Text.Encoding.UTF8, "application/json");


            var response = httpClient.PostAsync("https://localhost:44310/api/coach", content).Result;

            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync($"https://localhost:44310/api/coach/{id}").Result;

            var coach = JsonConvert.DeserializeObject<Coach>(response.Content.ReadAsStringAsync().Result);

            return View(coach);



        }


        [HttpPost]
        public IActionResult Edit(Coach coach)
        {

            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(coach), System.Text.Encoding.UTF8, "application/json");

            var response = httpClient.PutAsync($"https://localhost:44310/api/coach/{coach.CoachID}", content).Result;


            return RedirectToAction("Index");



        }


        public IActionResult Delete(int id)
        {
            HttpClient httpHttpClient = new HttpClient();
            var response = httpHttpClient.DeleteAsync($"https://localhost:44310/api/coach/{id}").Result;
            return RedirectToAction("Index");


        }






    }
}
