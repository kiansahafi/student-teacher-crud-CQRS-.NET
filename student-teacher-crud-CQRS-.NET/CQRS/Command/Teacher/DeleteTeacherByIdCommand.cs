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
            private readonly StudentContext _context;
            public DeleteTeacherByIdCommandHandler(StudentContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteTeacherByIdCommand command, CancellationToken cancellationToken)
            {
                var teacher = await _context.Teacher.FirstOrDefaultAsync(a => a.Id == command.Id, cancellationToken: cancellationToken);
                _context.Teacher.Remove(teacher);
                await _context.SaveChangesAsync(cancellationToken);
                return teacher.Id;
            }
        }

    }
}
