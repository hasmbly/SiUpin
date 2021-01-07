using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SiUpin.Shared.Uphs.Common;

namespace SiUpin.Shared.UphPasars.Common
{
    public class UphPasarDTO
    {
        public string UphPasarID { get; set; }

        [Required]
        public string UphID { get; set; }

        public int No { get; set; }
        public string id_pasar { get; set; }
        public string id_uph { get; set; }
        public string nama_uph { get; set; }

        [Required]
        public IList<string> mekanismes { get; set; } = new List<string>();
        public string mekanisme { get; set; }
        public string nilai_mekanisme { get; set; }
        public string lain { get; set; }

        [Required]
        public string jangkauan { get; set; }

        [Required]
        public string jml_penjualan { get; set; }

        [Required]
        public string omset { get; set; }

        public string user { get; set; }

        public UphDTO Uph { get; set; }
    }
}
