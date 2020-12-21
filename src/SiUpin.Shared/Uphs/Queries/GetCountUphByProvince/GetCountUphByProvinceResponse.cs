using System.Collections.Generic;

namespace SiUpin.Shared.Uphs.Queries.GetCountUphByProvince
{
    public class GetCountUphByProvinceResponse
    {
        public IList<UphByProvinceDTO> Datas { get; set; } = new List<UphByProvinceDTO>();
    }
}
