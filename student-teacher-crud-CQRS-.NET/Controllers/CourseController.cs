using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using course_teacher_crud_CQRS_.NET.CQRS.Command;
using course_teacher_crud_CQRS_.NET.CQRS.Queries;

namespace course_course_crud_CQRS_.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private IMediator Mediator;
        public CourseController(IMediator mediator)
        {
            this.Mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCourse(CreateCourseCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            return Ok(await Mediator.Send(new GetAllCourseQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            return Ok(await Mediator.Send(new GetCourseByIdQuery { Id = id }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, UpdateCourseCommand command)
        {
            command.Id = id;
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            //await Mediator.Publish(new student_course_crud_CQRS_.NET.Notifications.DeleteCourseNotification { CourseId = id });
            return Ok(await Mediator.Send(new DeleteCourseByIdCommand { Id = id }));
        }

    }
}
