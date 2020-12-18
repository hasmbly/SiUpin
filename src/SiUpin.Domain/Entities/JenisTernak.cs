using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiUpin.Domain.Entities
{
    [Table("jenisternaks")]
    public class JenisTernak
    {
        public string JenisTernakID { get; set; }

        public string id_ternak { get; set; }

        public string Name { get; set; }

        public IList<UphProduk> UphProduks { get; set; }
        public IList<UphBahanBaku> UphBahanBakus { get; set; }

        public JenisTernak()
        {
            UphProduks = new List<UphProduk>();
            UphBahanBakus = new List<UphBahanBaku>();
        }
    }
}