using System.ComponentModel.DataAnnotations.Schema;
using SiUpin.Domain.Common;

namespace SiUpin.Domain.Entities
{
    [Table("uphsdms")]
    public class UphSdm : AuditableEntity
    {
        public string UphSdmID { get; set; }
        public string UphID { get; set; }

        public string id_sdm { get; set; }
        public string id_uph { get; set; }
        public string nama_uph { get; set; }
        public string jml_sdm { get; set; }
        public string sop { get; set; }
        public string struktur_modal { get; set; }
        public string sumber_modal { get; set; }
        public string jml_modal { get; set; }
        public string nama_pelatihan { get; set; }
        public string penyelenggara { get; set; }
        public string lokasi { get; set; }
        public string tahun { get; set; }
        public string user { get; set; }
    }
}
