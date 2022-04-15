using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using student_teacher_crud_CQRS_.NET.Models;


namespace teacher_teacher_crud_CQRS_.NET.CQRS.Queries
{
    public class GetTeacherByIdQuery : IRequest<Teacher>
    {
        public int Id { get; set; }
        public class GetTeacherByIdQueryHandler : IRequestHandler<GetTeacherByIdQuery, Teacher>
        {
            private StudentContext context;
            public GetTeacherByIdQueryHandler(StudentContext context)
            {
                this.context = context;
            }
            public async Task<Teacher> Handle(GetTeacherByIdQuery query, CancellationToken cancellationToken)
            {
                var teacher = await context.Teacher.Where(a => a.Id == query.Id).FirstOrDefaultAsync();
                return teacher;
            }
        }

    }
}
