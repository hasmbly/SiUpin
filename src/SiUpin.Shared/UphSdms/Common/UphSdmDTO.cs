using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SiUpin.Shared.Uphs.Common;

namespace SiUpin.Shared.UphSdms.Common
{
    public class UphSdmDTO
    {

        public string UphSdmID { get; set; }

        public int No { get; set; }
        public string id_sdm { get; set; }
        public string id_uph { get; set; }
        public string nama_uph { get; set; }

        [Required]
        public string UphID { get; set; }

        [Required]
        public string jml_sdm { get; set; }

        [Required]
        public string struktur_modal { get; set; }

        [Required]
        public IList<string> sops { get; set; } = new List<string>();
        public string sop { get; set; }

        [Required]
        public IList<string> sumber_modals { get; set; } = new List<string>();
        public string sumber_modal { get; set; }
        public string jml_modal { get; set; }

        [Required]
        public string nama_pelatihan { get; set; }

        [Required]
        public string penyelenggara { get; set; }

        [Required]
        public string lokasi { get; set; } // provinsi

        [Required]
        public string tahun { get; set; }

        public string user { get; set; }

        public UphDTO Uph { get; set; }
    }
}
