using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using student_teacher_crud_CQRS_.NET.Models;


namespace teacher_teacher_crud_CQRS_.NET.CQRS.Queries
{
    public class GetAllTeacherQuery : IRequest<IEnumerable<Teacher>>
    {
        public class GetAllTeacherQueryHandler : IRequestHandler<GetAllTeacherQuery, IEnumerable<Teacher>>
        {
            private StudentContext context;
            public GetAllTeacherQueryHandler(StudentContext context)
            {
                this.context = context;
            }
            public async Task<IEnumerable<Teacher>> Handle(GetAllTeacherQuery query, CancellationToken cancellationToken)
            {
                var teacherList = await context.Teacher.ToListAsync();
                return teacherList;
            }
        }

    }
}
