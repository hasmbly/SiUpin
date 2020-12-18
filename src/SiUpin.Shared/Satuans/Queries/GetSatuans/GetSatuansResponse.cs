using System.Collections.Generic;

namespace SiUpin.Shared.Satuans.Queries.GetSatuans
{
    public class GetSatuansResponse
    {
        public IList<SatuanDTO> Data { get; set; }

        public GetSatuansResponse()
        {
            Data = new List<SatuanDTO>();
        }
    }
}
