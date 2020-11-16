using System.Collections.Generic;

namespace SiUpin.Shared.ProdukOlahans.Queries.GetProdukOlahans
{
    public class GetProdukOlahansResponse
    {
        public IList<ProdukOlahanDTO> ProdukOlahans { get; set; }

        public GetProdukOlahansResponse()
        {
            ProdukOlahans = new List<ProdukOlahanDTO>();
        }
    }
}
