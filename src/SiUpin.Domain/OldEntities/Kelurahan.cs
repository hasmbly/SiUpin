using System.ComponentModel.DataAnnotations.Schema;

namespace SiUpin.Domain.OldEntities
{
    [Table("kelurahan")]
    public class Kelurahan
    {
        public string id_kelurahan { get; set; }
        public string id_kecamatan_fk { get; set; }
        public string nama_kelurahan { get; set; }
    }
}
