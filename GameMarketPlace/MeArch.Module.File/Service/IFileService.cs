﻿using Core.Utilities.ResultTool;
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
        IDataResult<FileInfo> UploadFile(IFormFile file, FileOptionsParameter fileOptionsParameter);
        IDataResult<FileInfo> GetFile(string fileName, string directory);
        //IDataResult<FileInfo> GetFileInfo(string fileName, string directory);
        //IDataResult<byte[]> DownloadFile(string fileName, string directory);
    }
}
