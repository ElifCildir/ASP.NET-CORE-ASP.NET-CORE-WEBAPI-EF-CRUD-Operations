using EventProjectMvcCore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace EventProjectMvcCore.Controllers
{
    public class PlayerController : Controller
    {

        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync("https://localhost:44310/api/Player").Result;
            List<Player> player;
            player = JsonConvert.DeserializeObject<List<Player>>(response.Content.ReadAsStringAsync().Result);
            return View(player);


        }


        public IActionResult Create()
        {

            return View(new Player());

        }

        [HttpPost]
        public IActionResult Create(Player player)
        {
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(player), System.Text.Encoding.UTF8, "application/Json");

            var response = client.PostAsync("https://localhost:44310/api/Player", content).Result;

            return RedirectToAction("Index");


        }

        public IActionResult Edit(int id)
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync($"https://localhost:44310/api/Player/{id}").Result;
            var player = JsonConvert.DeserializeObject<Player>(response.Content.ReadAsStringAsync().Result);
            return View(player);



        }

        [HttpPost]
        public IActionResult Edit(Player player)
        {
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(player), System.Text.Encoding.UTF8, "application/Json");
            var response = client.PutAsync($"https://localhost:44310/api/Player/{player.PlayerID}   ", content).Result;
            return RedirectToAction("Index");



        }

        public IActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            var response = client.DeleteAsync($"https://localhost:44310/api/Player/{id}").Result;
            return RedirectToAction("Index");


        }





    }
}
