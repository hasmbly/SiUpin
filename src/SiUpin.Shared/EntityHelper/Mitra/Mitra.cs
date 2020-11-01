using System.Collections.Generic;

namespace SiUpin.Shared.EntityHelper.Mitra
{
    public class Mitra
    {
        public IDictionary<string, string> MitraJenisUsaha { get; set; }
        public IDictionary<string, string> MitraPerjanjian { get; set; }
        public IDictionary<string, string> MitraSasaran { get; set; }

        public Mitra()
        {
            MitraJenisUsaha = new Dictionary<string, string>()
            {
                {"1", "IPS"},
                {"2", "Importir"},
                {"3", "Industri Olahan Lain"},
                {"4", "Peternak"}
            };

            MitraPerjanjian = new Dictionary<string, string>()
            {
                {"true", "Ada"},
                {"false", "Tidak Ada"}
            };

            MitraSasaran = new Dictionary<string, string>()
            {
                {"1", "Kemitraan Pengolahan"},
                {"2", "Kemitraan Non Pengolahan"}
            };
        }
    }
}