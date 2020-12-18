using System.ComponentModel.DataAnnotations.Schema;

namespace SiUpin.Domain.OldEntities
{
    [Table("tb_gmp")]
    public class Gmp
    {
        public string id_gmp { get; set; }
        public string id_uph { get; set; }
        public string nama_gmp { get; set; }
        public string jml_gmp { get; set; }
        public string user { get; set; }
    }
}
