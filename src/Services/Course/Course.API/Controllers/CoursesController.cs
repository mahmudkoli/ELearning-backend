using Course.Application.Courses.Commands.CreateCourse;
using Course.Application.Courses.Commands.DeleteCourse;
using Course.Application.Courses.Commands.UpdateCourse;
using Course.Application.Courses.Queries.GetCourseById;
using Course.Application.Courses.Queries.GetCourses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Course.API.Controllers
{
    //[Authorize]
    public class CoursesController : ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(CoursesVm), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var result = await Mediator.Send(new GetCoursesQuery());
            return OkResult(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CourseDetailsVm), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await Mediator.Send(new GetCourseById { Id = id });
            return OkResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseCommand command)
        {
            var result = await Mediator.Send(command);
            return OkResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateCourseCommand command)
        {
            if (id != command.Id)
            {
                ModelState.AddModelError("", "Id does not match.");
                return ValidationResult(ModelState);
            }

            var result = await Mediator.Send(command);
            return OkResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await Mediator.Send(new DeleteCourseCommand { Id = id });
            return OkResult(result);
        }
    }
}
