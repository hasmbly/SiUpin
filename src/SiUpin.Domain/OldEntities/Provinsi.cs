using System.ComponentModel.DataAnnotations.Schema;

namespace SiUpin.Domain.OldEntities
{
    [Table("provinsi")]
    public class Provinsi
    {
        public string id_provinsi { get; set; }
        public string nama_provinsi { get; set; }
    }
}
