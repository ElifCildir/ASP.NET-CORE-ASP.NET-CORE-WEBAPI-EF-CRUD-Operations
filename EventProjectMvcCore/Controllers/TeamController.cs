using EventProjectMvcCore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace EventProjectMvcCore.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync("https://localhost:44310/api/team").Result;
            List<Team> teams;

            teams = JsonConvert.DeserializeObject<List<Team>>(response.Content.ReadAsStringAsync().Result);

            return View(teams);
        }

        [HttpGet]
        public IActionResult Create()

        {
            return View(new Team());



        }

        [HttpPost]
        public IActionResult Create(Team team)
        {

            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(team), System.Text.Encoding.UTF8, "application/Json");

            var response = client.PostAsync("https://localhost:44310/api/team", content).Result;
            return RedirectToAction("Index");


        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync($"https://localhost:44310/api/team/{id}").Result;

            var teams = JsonConvert.DeserializeObject<Team>(response.Content.ReadAsStringAsync().Result);
            return View(teams);

        }


        [HttpPost]
        public IActionResult Edit(Team team)
        {
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(team), System.Text.Encoding.UTF8, "application/Json");
            var response = client.PutAsync($"https://localhost:44310/api/team/{team.TeamID}", content).Result;
            return RedirectToAction("Index");

        }


        public IActionResult Delete(int id)
        {

            HttpClient client = new HttpClient();
            var response = client.DeleteAsync($"https://localhost:44310/api/team/{id}").Result;
            return RedirectToAction("Index");


        }




    }
}
