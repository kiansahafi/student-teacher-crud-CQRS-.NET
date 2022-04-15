using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace student_teacher_crud_CQRS_.NET.Notifications
{
    public class DeleteStudentNotification : INotification
    {
        public int StudentId { get; set; }
    }

    public class EmailHandler : INotificationHandler<DeleteStudentNotification>
    {
        public Task Handle(DeleteStudentNotification notification, CancellationToken cancellationToken)
        {
            int id = notification.StudentId;
            // send email
            return Task.CompletedTask;
        }
    }

    public class SMSHandler : INotificationHandler<DeleteStudentNotification>
    {
        public Task Handle(DeleteStudentNotification notification, CancellationToken cancellationToken)
        {
            int id = notification.StudentId;
            //send sms
            return Task.CompletedTask;
        }
    }

}
