using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using student_teacher_crud_CQRS_.NET.Models;


namespace teacher_teacher_crud_CQRS_.NET.CQRS.Command
{
    public class CreateTeacherCommand : IRequest<int>
    {
        public string FirstName { set; get; }

        public string LastName { set; get; }

        public string TeacherNumber { set; get; }

        public string EmailAddress { set; get; }

        public string PhoneNumber { set; get; }

        public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, int>
        {
            private readonly StudentContext _context;
            public CreateTeacherCommandHandler(StudentContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateTeacherCommand command, CancellationToken cancellationToken)
            {
                var teacher = new Teacher
                {
                    firstName = command.FirstName,
                    lastName = command.LastName,
                    teacherNumber = command.TeacherNumber,
                    emailAddress = command.EmailAddress,
                    phoneNumber = command.PhoneNumber
                };

                _context.Teacher.Add(teacher);
                await _context.SaveChangesAsync();
                return teacher.Id;
            }
        }

    }
}

