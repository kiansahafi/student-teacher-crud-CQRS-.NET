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

        public string firstName { set; get; }

        public string lastName { set; get; }

        public string teacherNumber { set; get; }

        public string emailAddress { set; get; }

        public string phoneNumber { set; get; }

        public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand, int>
        {
            private StudentContext context;
            public UpdateTeacherCommandHandler(StudentContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(UpdateTeacherCommand command, CancellationToken cancellationToken)
            {
                var teacher = context.Teacher.Where(a => a.Id == command.Id).FirstOrDefault();

                if (teacher == null)
                {
                    return default;
                }
                else
                {
                    teacher.firstName = command.firstName;
                    teacher.lastName = command.lastName;
                    teacher.teacherNumber = command.teacherNumber;
                    teacher.emailAddress = command.emailAddress;
                    teacher.phoneNumber = command.phoneNumber;
                    await context.SaveChangesAsync();
                    return teacher.Id;
                }
            }
        }

    }
}
