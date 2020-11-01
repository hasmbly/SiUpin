using System.Collections.Generic;

namespace SiUpin.Domain.Entities
{
    public class Kelurahan
    {
        public string KelurahanID { get; set; }

        public string id_kelurahan { get; set; }

        public string KecamatanID { get; set; }

        public string Name { get; set; }

        public Kecamatan Kecamatan { get; set; }

        public IList<User> Users { get; set; }
        public IList<Uph> Uphs { get; set; }

        public Kelurahan()
        {
            Users = new List<User>();
            Uphs = new List<Uph>();
        }
    }
}