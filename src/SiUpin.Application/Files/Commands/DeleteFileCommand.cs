using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared;
using SiUpin.Shared.Files.Commands.DeleteFile;

namespace SiUpin.Application.Files.Commands
{
    public class DeleteFileCommand : IRequestHandler<DeleteFileRequest, DeleteFileResponse>
    {
        private readonly IConfiguration _configuration;
        private readonly IFileService _fileService;
        private readonly ISiUpinDBContext _context;

        public DeleteFileCommand(ISiUpinDBContext context, IConfiguration configuration, IFileService fileService)
        {
            _configuration = configuration;
            _fileService = fileService;
            _context = context;
        }

        public async Task<DeleteFileResponse> Handle(DeleteFileRequest request, CancellationToken cancellationToken)
        {
            var result = new DeleteFileResponse();

            var options = _configuration.GetSection(SiUpinOptions.RootSection).Get<SiUpinOptions>();

            var file = await _context.Files
                .Where(x => x.EntityID == request.EntityID && x.EntityType == request.EntityType)
                .FirstOrDefaultAsync(cancellationToken);

            if (file != null)
            {
                var originalFileName = WebUtility.HtmlEncode(file.Name);

                string folderPath;
                if (options.Environment == "Linux")
                {
                    folderPath = Path.Combine(".", "SiUpinFiles", "Pictures");
                }
                else
                {
                    folderPath = Path.Combine("D:", "SiUpinFiles", "Pictures");
                }

                var removeDocumentResult = await _fileService.RemoveFile(folderPath, originalFileName);

                if (!removeDocumentResult.IsSuccessful)
                {
                    throw new Exception("Maaf ada kesalahan pada proses hapus File");
                }
            }

            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
