using System.Collections.Generic;

namespace SiUpin.Shared.ProdukOlahans.Queries.GetProdukOlahans
{
    public class GetProdukOlahansResponse
    {
        public IList<ProdukOlahanDTO> Data { get; set; }

        public GetProdukOlahansResponse()
        {
            Data = new List<ProdukOlahanDTO>();
        }
    }
}
