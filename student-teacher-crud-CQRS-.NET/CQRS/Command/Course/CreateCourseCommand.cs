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

        public int TeacherId { set; get; }

        public DateTime CourseTime { set; get; }

        public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, int>
        {
            private readonly StudentContext _context;
            public CreateCourseCommandHandler(StudentContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateCourseCommand command, CancellationToken cancellationToken)
            {
                var course = new Course
                {
                    Title = command.Title,
                    CourseNumber = command.CourseNumber,
                    TeacherId = command.TeacherId,
                    CourseTime = command.CourseTime
                };

                _context.Course.Add(course);
                await _context.SaveChangesAsync();
                return course.Id;
            }
        }

    }
}

