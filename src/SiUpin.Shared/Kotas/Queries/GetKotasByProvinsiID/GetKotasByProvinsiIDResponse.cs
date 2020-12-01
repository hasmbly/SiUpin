using System.Collections.Generic;

namespace SiUpin.Shared.Kotas.Queries.GetKotasByProvinsiID
{
    public class GetKotasByProvinsiIDResponse
    {
        public IList<KotaDTO> Data { get; set; }

        public GetKotasByProvinsiIDResponse() => Data = new List<KotaDTO>();
    }
}
