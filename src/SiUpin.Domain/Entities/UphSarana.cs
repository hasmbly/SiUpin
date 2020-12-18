using System.ComponentModel.DataAnnotations.Schema;
using SiUpin.Domain.Common;

namespace SiUpin.Domain.Entities
{
    [Table("uphsaranas")]
    public class UphSarana : AuditableEntity
    {
        public string UphSaranaID { get; set; }
        public string UphID { get; set; }

        public string id_sarana { get; set; }
        public string id_uph { get; set; }
        public string nama_uph { get; set; }

        public string tahun { get; set; }
        public string asal_bantuan { get; set; }
        public string lain { get; set; }
        public string nama_alat { get; set; }
        public string kapasitas_terpasang { get; set; }
        public string kapasitas_terpakai { get; set; }
        public string satuan { get; set; }
        public string jenis_mesin { get; set; }
        public string status { get; set; }
        public string alasan { get; set; }
        public string lain_alasan { get; set; }
        public string user { get; set; }
    }
}
