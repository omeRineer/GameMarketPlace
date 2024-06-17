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

        public async Task<IDataResult<FileInfo>> UploadFileAsync(Http.IFormFile file, FileOptionsParameter fileOptionsParameter)
        {
            var businessRules = BusinessTool.Run(ExtensionValidate(file.GetExtension()));
            if (!businessRules.Success) return new ErrorDataResult<FileInfo>(businessRules.Message);

            var fileInfo = CreateFileInfo(file, fileOptionsParameter);
            using (var fileStream = new IO.FileStream(fileInfo.FullPath, IO.FileMode.Create))
            {
                try
                {
                    await file.CopyToAsync(fileStream);
                    return new SuccessDataResult<FileInfo>(fileInfo);
                }
                catch (Exception ex)
                {
                    return new ErrorDataResult<FileInfo>(message: ex.Message);
                }
                finally
                {
                    fileStream.Close();
                }
            }
        }

        public IDataResult<FileInfo> GetFile(string fileName, string directory)
        {
            var fullPath = $"{FileOptions.FilePath}/{directory}/{fileName}";

            var businessRules = BusinessTool.Run(IsFileExist(fullPath));
            if (!businessRules.Success) return new ErrorDataResult<FileInfo>(businessRules.Message);

            return new SuccessDataResult<FileInfo>(new FileInfo
            {
                FullPath = fullPath,
                FileName = fileName,
                Extension = IO.Path.GetExtension(fileName)
            });

        }

    }

    public partial class FileService
    {
        private FileInfo CreateFileInfo(Http.IFormFile file, FileOptionsParameter fileOptionsParameter)
        {
            var extension = file.GetExtension().ToUpper();
            var fileName = CreateFileName(file, extension, fileOptionsParameter);
            var destinationDirectory = $"{FileOptions.FilePath}/{fileOptionsParameter.Directory}";

            if (!IO.Directory.Exists(destinationDirectory)) IO.Directory.CreateDirectory(destinationDirectory);

            var fullPath = $"{destinationDirectory}/{fileName}";

            return new Model.FileInfo
            {
                FullPath = fullPath,
                FileName = fileName,
                Extension = extension
            };
        }

        private IResult ExtensionValidate(string extension)
        {
            if (!FileOptions.Extensions.Contains(extension.ToUpper())) return new ErrorResult("Geçersiz Uzantı");

            return new SuccessResult();
        }

        private IResult IsFileExist(string fullPath)
        {
            var isExist = IO.File.Exists(fullPath);

            if (!isExist) return new ErrorResult("Dosya Bulunamadı");

            return new SuccessResult();
        }

        private string CreateFileName(Http.IFormFile file, string extension, FileOptionsParameter fileOptionsParameter)
        {
            var fileName = !string.IsNullOrEmpty(fileOptionsParameter.NameTemplate) ? $"{fileOptionsParameter.NameTemplate}{extension}"
                                                                                   : $"{file.FileName}";

            return fileName;
        }
    }
}
