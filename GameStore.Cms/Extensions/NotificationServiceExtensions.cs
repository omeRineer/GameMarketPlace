using Radzen;

namespace GameStore.Cms.Extensions
{
    public static class NotificationServiceExtensions
    {
        public static void Error(this NotificationService service, string summary, string detail = "")
        {
            var notificationMessage = GetMessage(NotificationSeverity.Error, summary, detail);

            service.Notify(notificationMessage);
        }

        public static void Success(this NotificationService service, string summary, string detail = "")
        {
            var notificationMessage = GetMessage(NotificationSeverity.Success, summary, detail);

            service.Notify(notificationMessage);
        }

        public static void Warning(this NotificationService service, string summary, string detail = "")
        {
            var notificationMessage = GetMessage(NotificationSeverity.Warning, summary, detail);

            service.Notify(notificationMessage);
        }

        public static void Info(this NotificationService service, string summary, string detail = "")
        {
            var notificationMessage = GetMessage(NotificationSeverity.Info, summary, detail);

            service.Notify(notificationMessage);
        }

        private static NotificationMessage GetMessage(NotificationSeverity notificationSeverity,
                                               string summary,
                                               string detail)
        {
            return new NotificationMessage
            {
                Severity = notificationSeverity,
                Summary = summary,
                Detail = detail,
                Duration = 3000
            };
        }
    }
}
