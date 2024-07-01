using Core.Utilities.ResultTool;
using MeArch.Module.File.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeArch.Module.File.Service
{
    public interface IFileService
    {
        Task<IResult> UploadFileAsync(byte[] fileBytes, FileOptionsParameter fileOptionsParameter);
    }
}
