using Core.Utilities.ResultTool;
using MeArch.Module.Storage.Models;
using MeArch.Module.Storage.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeArch.Module.Storage.Services.Local
{
    public class LocalStorageService : IStorageService
    {
        public Task<IResult> UploadAsync(byte[] binaryFile, string fileName, FileStorageUploadOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
