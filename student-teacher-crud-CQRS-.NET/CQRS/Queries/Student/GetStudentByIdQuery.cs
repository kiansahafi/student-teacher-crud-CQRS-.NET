using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using student_teacher_crud_CQRS_.NET.Models;

namespace student_teacher_crud_CQRS_.NET.CQRS.Queries
{
    public class GetStudentByIdQuery : IRequest<Student>
    {
        public int Id { get; set; }
        public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, Student>
        {
            private StudentContext context;
            public GetStudentByIdQueryHandler(StudentContext context)
            {
                this.context = context;
            }
            public async Task<Student> Handle(GetStudentByIdQuery query, CancellationToken cancellationToken)
            {
                var student = await context.Student.Where(a => a.Id == query.Id).FirstOrDefaultAsync();
                return student;
            }
        }

    }
}
