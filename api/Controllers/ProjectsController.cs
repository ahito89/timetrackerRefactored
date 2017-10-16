using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using service;
using api.viewmodels;
using System.Linq;
using data;
using System;

namespace api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ProjectsController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IProjectService projectService;
        
        public ProjectsController(IProjectService projectService, UserManager<IdentityUser> userManager)
        {
            this.projectService = projectService;
            this.userManager = userManager;
        }

        [HttpGet]
        public IEnumerable<ProjectViewModel> GetAllProjects()
        {   
            List<ProjectViewModel> projects = new List<ProjectViewModel>(); 
            projectService.GetProjects().Where(p => p.UserId == GetUserId()).ToList().ForEach( p => {
                ProjectViewModel project = new ProjectViewModel{
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description
                };
                projects.Add(project);
            });
            return projects;
        }

        [HttpGet("{id}", Name = "GetProject")]
        public IActionResult GetProject(long id)
        {
            var project = projectService.GetProject(id);
            if (project == null || project.UserId != GetUserId())
            {
                return NotFound();
            }
            else
            {
                ProjectViewModel model = new ProjectViewModel();
                model.Id = project.Id;
                model.Name = project.Name;
                model.Description = project.Description;

                return new ObjectResult(model);
            }
        }

        [HttpPost]
        public IActionResult CreateProject([FromBody]ProjectViewModel value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            Project project = new Project();
            project.UserId = GetUserId();
            project.Name = value.Name;
            project.Description = value.Description;
            projectService.CreateProject(project);
            return CreatedAtRoute("GetProject", new { id = project.Id }, value);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProject(long id, [FromBody] ProjectViewModel value)
        {
            var project = projectService.GetProject(id);
            if (project == null || project.UserId != GetUserId())
            {
                return NotFound();
            }
            if (value == null)
            {
                return BadRequest();
            }
            project.Name = value.Name;
            project.Description = value.Description;
            projectService.UpdateProject(project);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProject(long id)
        {
            var project = projectService.GetProject(id);
            if (project == null || project.UserId != GetUserId())
            {
                return NotFound();
            }
            projectService.DeleteProject(id);
            return new NoContentResult();
        }

        private Guid GetUserId()
        {
            Guid id = Guid.Empty;
            var test = Guid.TryParse(userManager.GetUserId(User), out id);
            return id;
        }
    }
}