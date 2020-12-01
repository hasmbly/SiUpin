using MediatR;

namespace SiUpin.Shared.Kotas.Queries.GetKotasByProvinsiID
{
    public class GetKotasByProvinsiIDRequest : IRequest<GetKotasByProvinsiIDResponse>
    {
        public string ProvinsiID { get; set; }
    }
}
