using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using student_teacher_crud_CQRS_.NET.Models;


namespace teacher_teacher_crud_CQRS_.NET.CQRS.Command
{
    public class CreateTeacherCommand : IRequest<int>
    {
        public string firstName { set; get; }

        public string lastName { set; get; }

        public string teacherNumber { set; get; }

        public string emailAddress { set; get; }

        public string phoneNumber { set; get; }

        public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, int>
        {
            private StudentContext context;
            public CreateTeacherCommandHandler(StudentContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(CreateTeacherCommand command, CancellationToken cancellationToken)
            {
                var teacher = new Teacher();
                teacher.firstName = command.firstName;
                teacher.lastName = command.lastName;
                teacher.teacherNumber = command.teacherNumber;
                teacher.emailAddress = command.emailAddress;
                teacher.phoneNumber = command.phoneNumber;

                context.Teacher.Add(teacher);
                await context.SaveChangesAsync();
                return teacher.Id;
            }
        }

    }
}

