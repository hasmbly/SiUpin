using MediatR;

namespace SiUpin.Shared.Files.Commands.DeleteFile
{
    public class DeleteFileRequest : IRequest<DeleteFileResponse>
    {
        public string EntityID { get; set; }
        public string EntityType { get; set; }
    }
}
