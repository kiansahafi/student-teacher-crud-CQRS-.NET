using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using student_teacher_crud_CQRS_.NET.Models;

namespace student_teacher_crud_CQRS_.NET.CQRS.Queries
{
    public class GetAllStudentQuery : IRequest<IEnumerable<Student>>
    {
        public class GetAllStudentQueryHandler : IRequestHandler<GetAllStudentQuery, IEnumerable<Student>>
        {
            private StudentContext context;
            public GetAllStudentQueryHandler(StudentContext context)
            {
                this.context = context;
            }
            public async Task<IEnumerable<Student>> Handle(GetAllStudentQuery query, CancellationToken cancellationToken)
            {
                var studentList = await context.Student.ToListAsync();
                return studentList;
            }
        }

    }
}
