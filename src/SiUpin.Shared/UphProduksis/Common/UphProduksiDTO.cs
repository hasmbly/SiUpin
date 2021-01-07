using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SiUpin.Shared.Uphs.Common;

namespace SiUpin.Shared.UphProduksis.Common
{
    public class UphProduksiDTO
    {
        public string UphProduksiID { get; set; }

        [Required]
        public string UphID { get; set; }

        public int No { get; set; }
        public string id_produksi { get; set; }
        public string id_uph { get; set; }
        public string nama_uph { get; set; }

        [Required]
        public string bahan_baku { get; set; }

        [Required]
        public string jml_produksi { get; set; }

        [Required]
        public string satuan { get; set; }

        [Required]
        public string jml_hari_produksi { get; set; }

        [Required]
        public string izin_edar { get; set; }
        public string jml_edar { get; set; }

        [Required]
        public IList<string> sertifikats { get; set; } = new List<string>();
        public string sertifikat { get; set; }
        public string jml_sertifikat { get; set; }

        public string gmp { get; set; }
        public string jml_gmp { get; set; }

        public string user { get; set; }

        public UphDTO Uph { get; set; }
    }
}
