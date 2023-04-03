using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebUI.Dtos.SkillDto;

namespace WebUI.WievComponents.Default
{
    public class _SkillPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _SkillPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:3509/api/Skill");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSkillDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}