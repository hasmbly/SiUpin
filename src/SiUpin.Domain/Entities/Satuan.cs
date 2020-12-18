using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiUpin.Domain.Entities
{
    [Table("satuans")]
    public class Satuan
    {
        public string SatuanID { get; set; }

        public string Name { get; set; }

        public IList<UphProduk> UphProduks { get; set; }
        public IList<UphBahanBaku> UphBahanBakus { get; set; }

        public Satuan()
        {
            UphProduks = new List<UphProduk>();
            UphBahanBakus = new List<UphBahanBaku>();
        }
    }
}