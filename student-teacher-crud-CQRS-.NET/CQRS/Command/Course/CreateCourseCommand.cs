using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using student_teacher_crud_CQRS_.NET.Models;

namespace course_teacher_crud_CQRS_.NET.CQRS.Command
{
    public class CreateCourseCommand : IRequest<int>
    {
        public string Title { set; get; }

        public int CourseNumber { set; get; }


        public Teacher Teacher { set; get; }

        public DateTime CourseTime { set; get; }

        public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, int>
        {
            private StudentContext context;
            public CreateCourseCommandHandler(StudentContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(CreateCourseCommand command, CancellationToken cancellationToken)
            {
                var course = new Course();
                course.Title = command.Title;
                course.CourseNumber = command.CourseNumber;
                course.Teacher = command.Teacher;
                course.CourseTime = command.CourseTime;

                context.Course.Add(course);
                await context.SaveChangesAsync();
                return course.Id;
            }
        }

    }
}

