using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using student_teacher_crud_CQRS_.NET.Models;

namespace student_teacher_crud_CQRS_.NET.CQRS.Command
{
    public class CreateStudentCommand : IRequest<int>
    {
        public string firstName { set; get; }

        public string lastName { set; get; }

        public Course aquiredClass { set; get; }

        public string emailAddress { set; get; }

        public string phoneNumber { set; get; }

        public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
        {
            private StudentContext context;
            public CreateStudentCommandHandler(StudentContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
            {
                var student = new Student();
                student.firstName = command.firstName;
                student.lastName = command.lastName;
                student.aquiredClass = command.aquiredClass;
                student.emailAddress = command.emailAddress;
                student.phoneNumber = command.phoneNumber;

                context.Student.Add(student);
                await context.SaveChangesAsync();
                return student.Id;
            }
        }

    }
}

