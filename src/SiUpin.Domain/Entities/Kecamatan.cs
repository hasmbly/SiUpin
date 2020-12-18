using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiUpin.Domain.Entities
{
    [Table("kecamatans")]
    public class Kecamatan
    {
        public string KecamatanID { get; set; }

        public string id_kecamatan { get; set; }

        public string KotaID { get; set; }

        public string Name { get; set; }

        public Kota Kota { get; set; }
        public IList<Kelurahan> Kelurahans { get; set; }
        public IList<User> Users { get; set; }
        public IList<Uph> Uphs { get; set; }

        public Kecamatan()
        {
            Kelurahans = new List<Kelurahan>();
            Users = new List<User>();
            Uphs = new List<Uph>();
        }
    }
}