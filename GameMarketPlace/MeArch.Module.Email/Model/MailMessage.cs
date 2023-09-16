using MeArch.Module.Email.Model.Enums;
using Microsoft.AspNetCore.Http;
using MimeKit;

namespace MeArch.Module.Email.Model
{
    public class MailMessage
    {
        public InternetAddress From { get; set; }
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; } = "Ömer Faruk Sandıkçı";
        public string Body { get; set; }
        public MailBodyTypeEnum BodyType { get; set; }
        public IFormFile[]? Files { get; set; }
    }
}
