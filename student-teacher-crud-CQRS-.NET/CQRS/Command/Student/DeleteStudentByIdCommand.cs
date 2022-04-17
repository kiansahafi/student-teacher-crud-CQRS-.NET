using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using student_teacher_crud_CQRS_.NET.Models;

namespace student_teacher_crud_CQRS_.NET.CQRS.Command
{
    public class DeleteStudentByIdCommand : IRequest<int>
    {
        public int Id { set; get; }
        public class DeleteStudentByIdCommandHandler : IRequestHandler<DeleteStudentByIdCommand, int>
        {
            private readonly StudentContext _context;
            public DeleteStudentByIdCommandHandler(StudentContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteStudentByIdCommand command, CancellationToken cancellationToken)
            {
                var student = await _context.Student.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                _context.Student.Remove(student);
                await _context.SaveChangesAsync();
                return student.Id;
            }
        }

    }
}
