using System.ComponentModel.DataAnnotations.Schema;

namespace SiUpin.Domain.OldEntities
{
    [Table("kota")]
    public class Kota
    {
        public string id_kota { get; set; }
        public string id_provinsi_fk { get; set; }
        public string nama_kota { get; set; }
    }
}
