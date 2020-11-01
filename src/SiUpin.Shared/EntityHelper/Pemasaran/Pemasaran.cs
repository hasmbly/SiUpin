using System.Collections.Generic;

namespace SiUpin.Shared.EntityHelper.Pemasaran
{
    public class Pemasaran
    {
        public IDictionary<string, string> PemasaranMekanisme { get; set; }
        public IDictionary<string, string> PemasaranJangkauan { get; set; }

        public Pemasaran()
        {
            PemasaranMekanisme = new Dictionary<string, string>()
            {
                {"1", "Langsung Ke Konsumen"},
                {"2", "Pedagang Perantara"},
                {"3", "Online"},
                {"4", "Lainnya"}
            };

            PemasaranJangkauan = new Dictionary<string, string>()
            {
                {"1", "DN Dalam Provinsi"},
                {"2", "DN Antar Provinsi"},
                {"3", "DN Dalam Kabupaten"},
                {"4", "DN Dalam Kecamatan"},
                {"5", "Luar Negri Eksport"}
            };
        }
    }
}
