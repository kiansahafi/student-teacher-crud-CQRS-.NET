using MediatR;
using Microsoft.AspNetCore.Mvc;
using teacher_teacher_crud_CQRS_.NET.CQRS.Command;
using teacher_teacher_crud_CQRS_.NET.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace teacher_teacher_crud_CQRS_.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private IMediator Mediator;
        public TeacherController(IMediator mediator)
        {
            this.Mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateTeacher(CreateTeacherCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTeachers()
        {
            return Ok(await Mediator.Send(new GetAllTeacherQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacherById(int id)
        {
            return Ok(await Mediator.Send(new GetTeacherByIdQuery { Id = id }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, UpdateTeacherCommand command)
        {
            command.Id = id;
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            //await Mediator.Publish(new student_teacher_crud_CQRS_.NET.Notifications.DeleteTeacherNotification { TeacherId = id });
            return Ok(await Mediator.Send(new DeleteTeacherByIdCommand { Id = id }));
        }

    }
}
