using MediatR;

namespace SiUpin.Shared.Kelurahans.Queries.GetKelurahansByKecamatanID
{
    public class GetKelurahansByKecamatanIDRequest : IRequest<GetKelurahansByKecamatanIDResponse>
    {
        public string KecamatanID { get; set; }
    }
}
