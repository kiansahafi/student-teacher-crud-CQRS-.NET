using MediatR;
using Microsoft.AspNetCore.Mvc;
using student_teacher_crud_CQRS_.NET.CQRS.Command;
using student_teacher_crud_CQRS_.NET.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_teacher_crud_CQRS_.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IMediator Mediator;
        public StudentController(IMediator mediator)
        {
            this.Mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudent(CreateStudentCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            return Ok(await Mediator.Send(new GetAllStudentQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            return Ok(await Mediator.Send(new GetStudentByIdQuery { Id = id }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, UpdateStudentCommand command)
        {
            command.Id = id;
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            //await Mediator.Publish(new Notifications.DeleteStudentNotification { StudentId = id });
            return Ok(await Mediator.Send(new DeleteStudentByIdCommand { Id = id }));
        }

    }
}
