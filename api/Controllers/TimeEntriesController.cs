using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using api.viewmodels;
using service;
using System.Linq;
using data;

namespace api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class TimeEntriesController : Controller
    {
        private ITimeEntryService timeEntryService;

        public TimeEntriesController(ITimeEntryService timeEntryService)
        {
            this.timeEntryService = timeEntryService;
        }

        [HttpGet("{id}")]
        [Route("project")]
        public IEnumerable<TimeEntryViewModel> GetAllEntriesForProject(long id)
        {
            List<TimeEntryViewModel> timeEntries = new List<TimeEntryViewModel>();
            timeEntryService.GetTimeEntries(id).ToList().ForEach(t => {
                TimeEntryViewModel timeEntry = new TimeEntryViewModel{
                    Id = t.Id,
                    MinutesWorked = t.MinutesWorked,
                    ProjectId = t.ProjectId
                };
                timeEntries.Add(timeEntry);
            });
            return timeEntries;
        }

        [HttpGet("{id}", Name = "GetTimeEntry")]
        public IActionResult GetTimeEntry(long id)
        {
            var timeEntry = timeEntryService.GetTimeEntry(id);
            if(timeEntry == null)
            {
                return NotFound();
            }
            else
            {
                TimeEntryViewModel model = new TimeEntryViewModel();
                model.Id = timeEntry.Id;
                model.MinutesWorked = timeEntry.MinutesWorked;
                model.ProjectId = timeEntry.ProjectId;

                return new ObjectResult(model);
            }
        }

        [HttpPost]
        public IActionResult CreateTimeEntry([FromBody] TimeEntryViewModel value)
        {
            if(value == null)
            {
                return BadRequest();
            }
            TimeEntry timeEntry = new TimeEntry();
            timeEntry.MinutesWorked = value.MinutesWorked;
            timeEntry.ProjectId = value.ProjectId;
            timeEntryService.CreateTimeEntry(timeEntry);
            return CreatedAtRoute("GetTimeEntry", new {id = value.Id }, value);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTimeEntry(long id, [FromBody] TimeEntryViewModel value)
        {
            var timeEntry = timeEntryService.GetTimeEntry(id);
            if (timeEntry == null)
            {
                return NotFound();
            }
            if (value == null)
            {
                return BadRequest();
            }
            timeEntry.MinutesWorked = value.MinutesWorked;
            timeEntry.ProjectId = value.ProjectId;
            timeEntryService.UpdateTimeEntry(timeEntry);         
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTimeEntry(long id)
        {
            var timeEntry = timeEntryService.GetTimeEntry(id);
            if (timeEntry == null)
            {
                return NotFound();
            }

            timeEntryService.DeleteTimeEntry(id);     
            return new NoContentResult();
        }
    }  
}