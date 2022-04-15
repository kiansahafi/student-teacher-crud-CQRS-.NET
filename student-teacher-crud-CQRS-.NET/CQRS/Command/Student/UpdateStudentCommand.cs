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

        public string firstName { set; get; }

        public string lastName { set; get; }

        public Course aquiredClass { set; get; }

        public string emailAddress { set; get; }

        public string phoneNumber { set; get; }

        public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, int>
        {
            private StudentContext context;
            public UpdateStudentCommandHandler(StudentContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
            {
                var student = context.Student.Where(a => a.Id == command.Id).FirstOrDefault();

                if (student == null)
                {
                    return default;
                }
                else
                {
                    student.firstName = command.firstName;
                    student.lastName = command.lastName;
                    student.aquiredClass = command.aquiredClass;
                    student.emailAddress = command.emailAddress;
                    student.phoneNumber = command.phoneNumber;
                    await context.SaveChangesAsync();
                    return student.Id;
                }
            }
        }

    }
}
