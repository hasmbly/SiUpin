using System.ComponentModel.DataAnnotations.Schema;
using SiUpin.Domain.Common;

namespace SiUpin.Domain.Entities
{

    [Table("uphpasars")]
    public class UphPasar : AuditableEntity
    {
        public string UphPasarID { get; set; }
        public string UphID { get; set; }

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
