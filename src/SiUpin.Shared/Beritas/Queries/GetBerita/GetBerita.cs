using MediatR;
using SiUpin.Shared.Beritas.Common;

namespace SiUpin.Shared.Beritas.Queries.GetBerita
{
    public class GetBeritaRequest : IRequest<GetBeritaResponse>
    {
        public string BeritaID { get; set; }
    }

    public class GetBeritaResponse : BeritaDTO
    {
    }
}
