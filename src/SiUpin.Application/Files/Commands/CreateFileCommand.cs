using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared;
using SiUpin.Shared.Files.Commands.CreateFile;

namespace SiUpin.Application.Files.Commands
{
    public class CreateFileCommand : IRequestHandler<CreateFileRequest, CreateFileResponse>
    {
        private readonly IConfiguration _configuration;
        private readonly IFileService _fileService;
        private readonly ISiUpinDBContext _context;

        public CreateFileCommand(ISiUpinDBContext context, IConfiguration configuration, IFileService fileService)
        {
            _configuration = configuration;
            _fileService = fileService;
            _context = context;
        }

        public async Task<CreateFileResponse> Handle(CreateFileRequest request, CancellationToken cancellationToken)
        {
            // create or update
            var result = new CreateFileResponse();

            var options = _configuration.GetSection(SiUpinOptions.RootSection).Get<SiUpinOptions>();

            var file = request.Files;

            if (file.Length > 0 && !string.IsNullOrEmpty(request.EntityID))
            {
                var originalFileName = WebUtility.HtmlEncode(file.FileName);

                var existingFile = await _context.Files.FirstOrDefaultAsync(x => x.EntityID == request.EntityID, cancellationToken);

                if (existingFile == null)
                {
                    // save file to directory
                    var processFileResult = await _fileService.ProcessFile(file);

                    if (processFileResult.IsSuccessful)
                    {
                        string folderPath;
                        if (options.Environment == "Linux")
                        {
                            folderPath = Path.Combine(".", "SiUpinFiles", "Pictures");
                        }
                        else
                        {
                            folderPath = Path.Combine("D:", "SiUpinFiles", "Pictures");
                        }

                        var trustedFileNameForFileStorage = $"{originalFileName}";

                        var saveDocumentResult = await _fileService.SaveFile(processFileResult.FileContent, folderPath, trustedFileNameForFileStorage);

                        if (!saveDocumentResult.IsSuccessful)
                        {
                            throw new Exception("Maaf ada kesalahan pada proses simpan File");
                        }
                    }
                    else
                    {
                        throw new Exception($"{processFileResult.ErrorMessage}");
                    }

                    // save file to db
                    var entity = new Domain.Entities.File
                    {
                        EntityID = request.EntityID,
                        EntityType = request.EntityType,
                        Name = originalFileName
                    };

                    await _context.Files.AddAsync(entity);
                }
                else
                {
                    string folderPath;
                    if (options.Environment == "Linux")
                    {
                        folderPath = Path.Combine(".", "SiUpinFiles", "Pictures");
                    }
                    else
                    {
                        folderPath = Path.Combine("D:", "SiUpinFiles", "Pictures");
                    }

                    // remove existing file
                    var removeDocumentResult = await _fileService.RemoveFile(folderPath, existingFile.Name);

                    // save new file to directory
                    var processFileResult = await _fileService.ProcessFile(file);

                    if (processFileResult.IsSuccessful)
                    {
                        if (options.Environment == "Linux")
                        {
                            folderPath = Path.Combine(".", "SiUpinFiles", "Pictures");
                        }
                        else
                        {
                            folderPath = Path.Combine("D:", "SiUpinFiles", "Pictures");
                        }

                        var trustedFileNameForFileStorage = $"{originalFileName}";

                        var saveDocumentResult = await _fileService.SaveFile(processFileResult.FileContent, folderPath, trustedFileNameForFileStorage);

                        if (!saveDocumentResult.IsSuccessful)
                        {
                            throw new Exception("Maaf ada kesalahan pada proses simpan File");
                        }
                    }
                    else
                    {
                        throw new Exception($"{processFileResult.ErrorMessage}");
                    }

                    // update file name to database
                    existingFile.Name = originalFileName;
                }

                await _context.SaveChangesAsync(cancellationToken);
            }

            return result;
        }
    }
}
