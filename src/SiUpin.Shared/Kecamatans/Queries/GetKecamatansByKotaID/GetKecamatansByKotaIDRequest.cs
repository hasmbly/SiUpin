using MediatR;

namespace SiUpin.Shared.Kecamatans.Queries.GetKecamatansByKotaID
{
    public class GetKecamatansByKotaIDRequest : IRequest<GetKecamatansByKotaIDResponse>
    {
        public string KotaID { get; set; }
    }
}
