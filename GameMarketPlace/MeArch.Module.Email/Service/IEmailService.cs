using Core.Utilities.ResultTool;
using MeArch.Module.Email.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeArch.Module.Email.Service
{
    public interface IEmailService
    {
        Task<IResult> SendAsync(MailMessage message);
    }
}
