using MediatR;

namespace SiUpin.Shared.Files.Queries.GetFiles
{
    public class GetFilesRequest : IRequest<GetFilesResponse>
    {
        public string EntityType { get; set; }
        public string EntityID { get; set; }
    }
}
