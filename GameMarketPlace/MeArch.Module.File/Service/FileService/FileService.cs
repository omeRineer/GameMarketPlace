using Core.Utilities.BusinessRules;
using Core.Utilities.ResultTool;
using MeArch.Module.File.Extensions;
using MeArch.Module.File.Model;
using MeArch.Module.File.Model.Options;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Http = Microsoft.AspNetCore.Http;
using IO = System.IO;

namespace MeArch.Module.File.Service.FileService
{
    public partial class FileService : IFileService
    {
        readonly FileOptions FileOptions;
        public FileService(IOptions<FileOptions> options)
        {
            FileOptions = options.Value;
        }

        public async Task<IResult> UploadFileAsync(byte[] fileBytes, FileOptionsParameter fileOptionsParameter)
        {
            var destinationDirectory = $"{FileOptions.FilePath}/{fileOptionsParameter.Directory}";
            var fullPath = $"{destinationDirectory}/{fileOptionsParameter.NameTemplate}";

            if (!IO.Directory.Exists(destinationDirectory)) IO.Directory.CreateDirectory(destinationDirectory);

            await IO.File.WriteAllBytesAsync(fullPath, fileBytes);

            return new SuccessResult();
        }
    }
}
