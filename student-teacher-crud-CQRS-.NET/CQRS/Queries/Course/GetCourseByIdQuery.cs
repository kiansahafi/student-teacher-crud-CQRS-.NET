using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using student_teacher_crud_CQRS_.NET.Models;

namespace course_teacher_crud_CQRS_.NET.CQRS.Queries
{
    public class GetCourseByIdQuery : IRequest<Course>
    {
        public int Id { get; set; }
        public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, Course>
        {
            private StudentContext context;
            public GetCourseByIdQueryHandler(StudentContext context)
            {
                this.context = context;
            }
            public async Task<Course> Handle(GetCourseByIdQuery query, CancellationToken cancellationToken)
            {
                var course = await context.Course.Where(a => a.Id == query.Id).FirstOrDefaultAsync();
                return course;
            }
        }

    }
}
