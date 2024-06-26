using BackgroundJobs.Schedulers.Base;
using Configuration;
using Core.Utilities.ServiceTools;
using DataAccess.Concrete.EntityFramework.General;
using MeArch.Module.Email.Model;
using MeArch.Module.Email.Model.Enums;
using MeArch.Module.Email.Service;
using MeArch.Module.Templates;
using MeArch.Module.Templates.Service;
using Microsoft.VisualBasic;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundJobs.Schedulers.RecurringJobs
{
    public class WeeklyCampaignEmailJob : IRecurringJob
    {
        readonly IUserRepository _userRepository;
        readonly IEmailService _emailService;

        public WeeklyCampaignEmailJob()
        {
            _userRepository = StaticServiceProvider.GetService<IUserRepository>();
            _emailService = StaticServiceProvider.GetService<IEmailService>(); ;
        }

        public async Task Run()
        {
            var users = await _userRepository.GetListAsync();

            foreach (var user in users)
            {
                await _emailService.SendAsync(new MailMessage
                {
                    Subject = "Kampanya Maili",
                    Body = await RazorEngine.CompileRenderAsync(Template.Email.CampaignTemplate, ""),
                    BodyType = MailBodyTypeEnum.HTML,
                    From = new MailboxAddress(CoreConfiguration.EmailOptions.From, CoreConfiguration.EmailOptions.UserName),
                    To = new List<MailboxAddress>
                    {
                        new MailboxAddress(CoreConfiguration.EmailOptions.From, user.Email)
                    }
                });
            }
        }
    }
}
