using System.Collections.Generic;

namespace SiUpin.Shared.EntityHelper.Sarana
{
    public class Sarana
    {
        public IDictionary<string, string> SaranaJenisMesin { get; set; }
        public IDictionary<string, string> SaranaTidakBeroperasi { get; set; }

        public Sarana()
        {
            SaranaJenisMesin = new Dictionary<string, string>()
            {
                {"1", "Mesin Utama"},
                {"2", "Mesin Pendukung"}
            };

            SaranaTidakBeroperasi = new Dictionary<string, string>()
            {
                {"1", "Kekurangan Bahan Bahan Baku"},
                {"2", "Rusak"},
                {"3", "Alat tidak sesuai"},
                {"4", "Hilang"}
            };
        }
    }
}
