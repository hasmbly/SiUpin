using System.Collections.Generic;

namespace SiUpin.Domain.Entities
{
    public class JenisKomoditi
    {
        public string JenisKomoditiID { get; set; }

        public string id_komoditi { get; set; }

        public string Name { get; set; }

        public IList<ProdukOlahan> ProdukOlahans { get; set; }

        public JenisKomoditi()
        {
            ProdukOlahans = new List<ProdukOlahan>();
        }
    }
}