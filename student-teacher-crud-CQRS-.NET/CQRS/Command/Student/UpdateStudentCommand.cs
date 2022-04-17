using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using student_teacher_crud_CQRS_.NET.Models;

namespace student_teacher_crud_CQRS_.NET.CQRS.Command
{
    public class UpdateStudentCommand : IRequest<int>
    {
        public int Id { set; get; }

        public string FirstName { set; get; }

        public string LastName { set; get; }

        public int AquiredClassId { set; get; }

        public string emailAddress { set; get; }

        public string phoneNumber { set; get; }

        public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, int>
        {
            private readonly StudentContext _context;
            public UpdateStudentCommandHandler(StudentContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
            {
                var student = _context.Student.FirstOrDefault(a => a.Id == command.Id);

                if (student == null) return default;
                student.firstName = command.FirstName;
                student.lastName = command.LastName;
                student.auiredClassId = command.AquiredClassId;
                student.emailAddress = command.emailAddress;
                student.phoneNumber = command.phoneNumber;
                await _context.SaveChangesAsync();
                return student.Id;

            }
        }

    }
}
