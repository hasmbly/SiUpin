using System.Collections.Generic;

namespace SiUpin.Domain.Entities
{
    public class Satuan
    {
        public string SatuanID { get; set; }

        public string Name { get; set; }

        public IList<UphProduk> UphProduks { get; set; }

        public Satuan()
        {
            UphProduks = new List<UphProduk>();
        }
    }
}