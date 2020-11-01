using System.Collections.Generic;

namespace SiUpin.Domain.Entities
{
    public class Kota
    {
        public string KotaID { get; set; }

        public string id_kota { get; set; }

        public string ProvinsiID { get; set; }

        public string Name { get; set; }

        public Provinsi Provinsi { get; set; }
        public IList<Kecamatan> Kecamatans { get; set; }
        public IList<User> Users { get; set; }
        public IList<Uph> Uphs { get; set; }

        public Kota()
        {
            Kecamatans = new List<Kecamatan>();
            Users = new List<User>();
            Uphs = new List<Uph>();
        }
    }
}