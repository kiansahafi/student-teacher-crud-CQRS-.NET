using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace teacher_teacher_crud_CQRS_.NET.Notifications
{
    public class DeleteTeacherNotification : INotification
    {
        public int TeacherId { get; set; }
    }

    public class EmailHandler : INotificationHandler<DeleteTeacherNotification>
    {
        public Task Handle(DeleteTeacherNotification notification, CancellationToken cancellationToken)
        {
            int id = notification.TeacherId;
            // send email
            return Task.CompletedTask;
        }
    }

    public class SMSHandler : INotificationHandler<DeleteTeacherNotification>
    {
        public Task Handle(DeleteTeacherNotification notification, CancellationToken cancellationToken)
        {
            int id = notification.TeacherId;
            //send sms
            return Task.CompletedTask;
        }
    }

}
