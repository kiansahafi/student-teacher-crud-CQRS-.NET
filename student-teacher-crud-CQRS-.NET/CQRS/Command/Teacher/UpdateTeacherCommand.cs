using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using student_teacher_crud_CQRS_.NET.Models;


namespace teacher_teacher_crud_CQRS_.NET.CQRS.Command
{
    public class UpdateTeacherCommand : IRequest<int>
    {
        public int Id { set; get; }

        public string FirstName { set; get; }

        public string LastName { set; get; }

        public string TeacherNumber { set; get; }

        public string EmailAddress { set; get; }

        public string PhoneNumber { set; get; }

        public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand, int>
        {
            private readonly StudentContext _context;
            public UpdateTeacherCommandHandler(StudentContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateTeacherCommand command, CancellationToken cancellationToken)
            {
                var teacher = _context.Teacher.FirstOrDefault(a => a.Id == command.Id);

                if (teacher == null) return default;
                teacher.firstName = command.FirstName;
                teacher.lastName = command.LastName;
                teacher.teacherNumber = command.TeacherNumber;
                teacher.emailAddress = command.EmailAddress;
                teacher.phoneNumber = command.PhoneNumber;
                await _context.SaveChangesAsync();
                return teacher.Id;

            }
        }

    }
}
