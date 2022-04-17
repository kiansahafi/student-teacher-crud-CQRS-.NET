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

        public int TeacherId { set; get; }

        public DateTime CourseTime { set; get; }

        public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, int>
        {
            private readonly StudentContext _context;
            public UpdateCourseCommandHandler(StudentContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateCourseCommand command, CancellationToken cancellationToken)
            {
                var course = _context.Course.FirstOrDefault(a => a.Id == command.Id);

                if (course == null) return default;
                course.Title = command.Title;
                course.CourseNumber = command.CourseNumber;
                course.TeacherId = command.TeacherId;
                course.CourseTime = command.CourseTime;
                await _context.SaveChangesAsync();
                return course.Id;

            }
        }

    }
}
