using System.Collections.Generic;

namespace SiUpin.Shared.Kecamatans.Queries.GetKecamatansByKotaID
{
    public class GetKecamatansByKotaIDResponse
    {
        public IList<KecamatanDTO> Data { get; set; }

        public GetKecamatansByKotaIDResponse() => Data = new List<KecamatanDTO>();
    }
}
