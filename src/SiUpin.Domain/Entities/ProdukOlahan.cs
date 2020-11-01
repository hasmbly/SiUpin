using System.Collections.Generic;

namespace SiUpin.Domain.Entities
{
    public class ProdukOlahan
    {
        public string ProdukOlahanID { get; set; }

        public string id_olahan { get; set; }

        public string JenisKomoditiID { get; set; }

        public string Name { get; set; }

        public JenisKomoditi JenisKomoditi { get; set; }

        public IList<UphProduk> UphProduks { get; set; }

        public ProdukOlahan()
        {
            UphProduks = new List<UphProduk>();

        }
    }
}