using System.ComponentModel.DataAnnotations.Schema;

namespace SiUpin.Domain.OldEntities
{
    [Table("tb_pasar")]
    public class Pasar
    {
        public string id_pasar { get; set; }
        public string id_uph { get; set; }
        public string nama_uph { get; set; }
        public string mekanisme { get; set; }
        public string nilai_mekanisme { get; set; }
        public string jangkauan { get; set; }
        public string jml_penjualan { get; set; }
        public string omset { get; set; }
        public string lain { get; set; }
        public string user { get; set; }
    }
}
