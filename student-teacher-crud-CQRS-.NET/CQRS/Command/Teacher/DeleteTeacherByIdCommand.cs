using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using student_teacher_crud_CQRS_.NET.Models;

namespace teacher_teacher_crud_CQRS_.NET.CQRS.Command
{
    public class DeleteTeacherByIdCommand : IRequest<int>
    {
        public int Id { set; get; }
        public class DeleteTeacherByIdCommandHandler : IRequestHandler<DeleteTeacherByIdCommand, int>
        {
            private StudentContext context;
            public DeleteTeacherByIdCommandHandler(StudentContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(DeleteTeacherByIdCommand command, CancellationToken cancellationToken)
            {
                var teacher = await context.Teacher.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                context.Teacher.Remove(teacher);
                await context.SaveChangesAsync();
                return teacher.Id;
            }
        }

    }
}
