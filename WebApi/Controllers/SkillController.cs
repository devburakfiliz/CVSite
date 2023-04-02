using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _skillService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddProject(Skill skill)
        {
            _skillService.TInsert(skill);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id)
        {
            var values = _skillService.TGetById(id);
            _skillService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateProject(Skill skill)
        {
            _skillService.TUpdate(skill);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetProject(int id)
        {
            var values = _skillService.TGetById(id);

            return Ok(values);
        }
    }
}
