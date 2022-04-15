using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using student_teacher_crud_CQRS_.NET.Models;

namespace course_teacher_crud_CQRS_.NET.CQRS.Command
{
    public class DeleteCourseByIdCommand : IRequest<int>
    {
        public int Id { set; get; }
        public class DeleteCourseByIdCommandHandler : IRequestHandler<DeleteCourseByIdCommand, int>
        {
            private StudentContext context;
            public DeleteCourseByIdCommandHandler(StudentContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(DeleteCourseByIdCommand command, CancellationToken cancellationToken)
            {
                var course = await context.Course.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                context.Course.Remove(course);
                await context.SaveChangesAsync();
                return course.Id;
            }
        }

    }
}
