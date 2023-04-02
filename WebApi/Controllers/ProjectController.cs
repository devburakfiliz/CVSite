using Business.Abstract;
using DataAccess.Abstract;
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
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _projectService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddProject(Project project)
        {
            _projectService.TInsert(project);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id)
        {
            var values = _projectService.TGetById(id);
            _projectService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateProject(Project project)
        {
            _projectService.TUpdate(project);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetProject(int id)
        {
            var values = _projectService.TGetById(id);

            return Ok(values);
        }
    }
}
