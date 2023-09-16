using Core.Utilities.ResultTool;
using MailKit.Net.Smtp;
using MeArch.Module.Email.Model;
using MeArch.Module.Email.Model.Enums;
using MeArch.Module.Email.Model.Options;
using Microsoft.Extensions.Options;
using MimeKit;

namespace MeArch.Module.Email.Service.MailService
{
    public class MimeKitMailService : IEmailService
    {
        readonly EmailOptions EmailOptions;

        public MimeKitMailService(IOptions<EmailOptions> options)
        {
            EmailOptions = options.Value;
        }

        public async Task<IResult> SendAsync(MailMessage mailMessage)
        {
            var mimeMessage = CreateMessage(mailMessage);

            using (var smtpClient = new SmtpClient())
            {
                try
                {
                    await smtpClient.ConnectAsync(EmailOptions.Host, EmailOptions.Port, EmailOptions.UseSSL);
                    await smtpClient.AuthenticateAsync(EmailOptions.UserName, EmailOptions.Password);

                    await smtpClient.SendAsync(mimeMessage);
                }
                catch
                {
                    await smtpClient.DisconnectAsync(true);
                    smtpClient.Dispose();
                }
            }

            return new SuccessResult();
        }

        private MimeMessage CreateMessage(MailMessage message)
        {
            var mimeMessage = new MimeMessage();

            mimeMessage.From.Add(message.From);
            mimeMessage.To.AddRange(message.To);

            mimeMessage.Subject = message.Subject;
            mimeMessage.Body = BodyBuild(message);

            mimeMessage.Date = DateTime.Now;

            return mimeMessage;
        }

        private MimeEntity BodyBuild(MailMessage message)
        {
            var bodyBuilder = new BodyBuilder();

            switch (message.BodyType)
            {
                case MailBodyTypeEnum.HTML:
                    bodyBuilder.HtmlBody = message.Body; break;

                default:
                    bodyBuilder.TextBody = message.Body; break;
            }

            if (message.Files is not null)
            {
                foreach (var file in message.Files)
                {
                    bodyBuilder.Attachments.Add(new MimePart()
                    {
                        Content = new MimeContent(file.OpenReadStream()),
                        FileName = file.FileName
                    });
                }
            }


            return bodyBuilder.ToMessageBody();
        }
    }
}
