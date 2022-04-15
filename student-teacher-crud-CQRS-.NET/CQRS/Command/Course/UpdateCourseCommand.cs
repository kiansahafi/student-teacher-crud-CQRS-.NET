using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using student_teacher_crud_CQRS_.NET.Models;

namespace course_teacher_crud_CQRS_.NET.CQRS.Command
{
    public class UpdateCourseCommand : IRequest<int>
    {
        public int Id { set; get; }

        public string Title { set; get; }

        public int CourseNumber { set; get; }

        public Teacher Teacher { set; get; }

        public DateTime CourseTime { set; get; }

        public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, int>
        {
            private StudentContext context;
            public UpdateCourseCommandHandler(StudentContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(UpdateCourseCommand command, CancellationToken cancellationToken)
            {
                var course = context.Course.Where(a => a.Id == command.Id).FirstOrDefault();

                if (course == null)
                {
                    return default;
                }
                else
                {
                    course.Title = command.Title;
                    course.CourseNumber = command.CourseNumber;
                    course.Teacher = command.Teacher;
                    course.CourseTime = command.CourseTime;
                    await context.SaveChangesAsync();
                    return course.Id;
                }
            }
        }

    }
}
