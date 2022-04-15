using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using student_teacher_crud_CQRS_.NET.Models;

namespace course_teacher_crud_CQRS_.NET.CQRS.Queries
{
    public class GetAllCourseQuery : IRequest<IEnumerable<Course>>
    {
        public class GetAllCourseQueryHandler : IRequestHandler<GetAllCourseQuery, IEnumerable<Course>>
        {
            private StudentContext context;
            public GetAllCourseQueryHandler(StudentContext context)
            {
                this.context = context;
            }
            public async Task<IEnumerable<Course>> Handle(GetAllCourseQuery query, CancellationToken cancellationToken)
            {
                var courseList = await context.Course.ToListAsync();
                return courseList;
            }
        }

    }
}
