using MediatR;
using Microsoft.AspNetCore.Http;

namespace SiUpin.Shared.Files.Commands.CreateFile
{
    public class CreateFileRequest : IRequest<CreateFileResponse>
    {
        public string EntityID { get; set; }
        public string EntityType { get; set; }

        public IFormFile Files { get; set; }
    }
}
