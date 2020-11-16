using System.Collections.Generic;
using SiUpin.Shared.Pesans.Queries.Common;

namespace SiUpin.Shared.Pesans.Queries.GetPesans
{
    public class GetPesansResponse
    {
        public IList<PesanDTO> Data { get; set; }

        public GetPesansResponse()
        {
            Data = new List<PesanDTO>();
        }
    }
}
