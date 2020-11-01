using System.Collections.Generic;

namespace SiUpin.Domain.Entities
{
    public class UphProduk
    {
        public string UphProdukID { get; set; }

        public string UphID { get; set; }
#pragma warning disable CS8632
        public string? ProdukOlahanID { get; set; }
        public string? JenisTernakID { get; set; }
        public string? SatuanID { get; set; }

        public string Name { get; set; }
        public string Harga { get; set; }
        public int Berat { get; set; }
        public string Description { get; set; }

        public Uph Uph { get; set; }
        public ProdukOlahan ProdukOlahan { get; set; }
        public JenisTernak JenisTernak { get; set; }
        public Satuan Satuan { get; set; }

        public IList<File> Files { get; set; }

        public UphProduk()
        {
            Files = new List<File>();
        }
    }
}