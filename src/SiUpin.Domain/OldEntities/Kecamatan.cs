using System.ComponentModel.DataAnnotations.Schema;

namespace SiUpin.Domain.OldEntities
{
    [Table("kecamatan")]
    public class Kecamatan
    {
        public string id_kecamatan { get; set; }
        public string id_kota_fk { get; set; }
        public string nama_kecamatan { get; set; }
    }
}
