using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace course_course_crud_CQRS_.NET.Notifications
{
    public class DeleteCourseNotification : INotification
    {
        public int CourseId { get; set; }
    }

    public class EmailHandler : INotificationHandler<DeleteCourseNotification>
    {
        public Task Handle(DeleteCourseNotification notification, CancellationToken cancellationToken)
        {
            int id = notification.CourseId;
            // send email
            return Task.CompletedTask;
        }
    }

    public class SMSHandler : INotificationHandler<DeleteCourseNotification>
    {
        public Task Handle(DeleteCourseNotification notification, CancellationToken cancellationToken)
        {
            int id = notification.CourseId;
            //send sms
            return Task.CompletedTask;
        }
    }

}
