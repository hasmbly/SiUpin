using System.Collections.Generic;

namespace SiUpin.Shared.EntityHelper.Produksi
{
    public class Produksi
    {
        public IDictionary<string, string> ProduksiSertifikat { get; set; }

        public Produksi()
        {
            ProduksiSertifikat = new Dictionary<string, string>()
            {
                {"1", "Organik"},
                {"2", "Halal"},
                {"3", "Sertifikat Penyuluhan"},
                {"4", "NKV"},
            };
        }
    }
}
