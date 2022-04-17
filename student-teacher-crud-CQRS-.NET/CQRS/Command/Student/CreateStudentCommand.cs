using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using student_teacher_crud_CQRS_.NET.Models;

namespace student_teacher_crud_CQRS_.NET.CQRS.Command
{
    public class CreateStudentCommand : IRequest<int>
    {
        public string FirstName { set; get; }

        public string LastName { set; get; }

        public int AquiredClassId { set; get; }

        public string EmailAddress { set; get; }

        public string PhoneNumber { set; get; }

        public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
        {
            private readonly StudentContext _context;
            public CreateStudentCommandHandler(StudentContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
            {
                var student = new Student
                {
                    firstName = command.FirstName,
                    lastName = command.LastName,
                    auiredClassId = command.AquiredClassId,
                    emailAddress = command.EmailAddress,
                    phoneNumber = command.PhoneNumber
                };

                _context.Student.Add(student);
                await _context.SaveChangesAsync();
                return student.Id;
            }
        }

    }
}

