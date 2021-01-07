using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SiUpin.Shared.Uphs.Common;

namespace SiUpin.Shared.UphSaranas.Common
{
    public class UphSaranaDTO
    {
        public string UphSaranaID { get; set; }

        [Required]
        public string UphID { get; set; }

        public int No { get; set; }
        public string id_sarana { get; set; }
        public string id_uph { get; set; }
        public string nama_uph { get; set; }

        [Required]
        public string tahun { get; set; }

        [Required]
        public IList<string> asal_bantuans { get; set; } = new List<string>();
        public string asal_bantuan { get; set; }
        public string lain { get; set; }

        [Required]
        public string nama_alat { get; set; }

        [Required]
        public string kapasitas_terpasang { get; set; }

        [Required]
        public string kapasitas_terpakai { get; set; }

        [Required]
        public string satuan { get; set; }

        [Required]
        public string jenis_mesin { get; set; }

        [Required]
        public string status { get; set; }

        [Required]
        public IList<string> alasans { get; set; } = new List<string>();
        public string alasan { get; set; }
        public string lain_alasan { get; set; }

        public string user { get; set; }

        public UphDTO Uph { get; set; }
    }
}
