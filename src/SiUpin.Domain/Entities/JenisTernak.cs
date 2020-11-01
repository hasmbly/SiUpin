using System.Collections.Generic;

namespace SiUpin.Domain.Entities
{
    public class JenisTernak
    {
        public string JenisTernakID { get; set; }

        public string id_ternak { get; set; }

        public string Name { get; set; }

        public IList<UphProduk> UphProduks { get; set; }

        public JenisTernak()
        {
            UphProduks = new List<UphProduk>();

        }
    }
}