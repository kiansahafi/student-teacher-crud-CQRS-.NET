using System;
namespace student_teacher_crud_CQRS_.NET.Models
{
    public class Teacher : BaseModel
    {
        public string firstName { set; get; }

        public string lastName { set; get; }

        public string teacherNumber { set; get; }

        public string emailAddress { set; get; }

        public string phoneNumber { set; get; }
    }
}
