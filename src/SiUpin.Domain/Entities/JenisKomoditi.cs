using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiUpin.Domain.Entities
{
    [Table("jeniskomoditis")]
    public class JenisKomoditi
    {
        public string JenisKomoditiID { get; set; }

        public string id_komoditi { get; set; }

        public string Name { get; set; }

        public IList<ProdukOlahan> ProdukOlahans { get; set; }
        public IList<UphBahanBaku> UphBahanBakus { get; set; }

        public JenisKomoditi()
        {
            ProdukOlahans = new List<ProdukOlahan>();
            UphBahanBakus = new List<UphBahanBaku>();
        }
    }
}