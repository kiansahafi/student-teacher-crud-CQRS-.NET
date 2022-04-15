using System;
namespace student_teacher_crud_CQRS_.NET.Models
{
    public class Course : BaseModel
    {
        public string Title { set; get; }

        public int CourseNumber { set; get; }

        public int TeacherId { set; get; }

        public Teacher Teacher { set; get; }

        public DateTime CourseTime { set; get; }
    }
}
