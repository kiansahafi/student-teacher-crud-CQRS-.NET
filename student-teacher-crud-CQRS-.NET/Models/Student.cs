using System;
namespace student_teacher_crud_CQRS_.NET.Models
{
    public class Student : BaseModel
    {
        public string firstName { set; get; }

        public string lastName { set; get; }

        public int auiredClassId { set; get; }

        public Course aquiredClass { set; get; }

        public string emailAddress { set; get; }

        public string phoneNumber { set; get; }
    }
}
