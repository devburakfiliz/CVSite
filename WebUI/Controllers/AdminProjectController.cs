﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebUI.Dtos.ProjectDto;

namespace WebUI.Controllers
{
    public class AdminProjectController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminProjectController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:3509/api/Project");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProjectDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProject(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:3509/api/Project/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProjectDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProject(UpdateProjectDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:3509/api/Project/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteProject(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:3509/api/Project/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]
        public IActionResult AddProject()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProject(CreateProjectDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:3509/api/Project", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
