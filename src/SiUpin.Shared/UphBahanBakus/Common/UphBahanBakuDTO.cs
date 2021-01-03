using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SiUpin.Shared.JenisKomiditis.Common.GetAllJenisKomiditi;
using SiUpin.Shared.JenisTernaks.Queries.Common;
using SiUpin.Shared.Satuans.Queries.GetSatuans;
using SiUpin.Shared.Uphs.Common;

namespace SiUpin.Shared.UphBahanBakus.Common
{
    public class UphBahanBakuDTO
    {
        public string UphBahanBakuID { get; set; }
        [Required]
        public string UphID { get; set; }

        public int No { get; set; }
        public string id_bahan_baku { get; set; }
        public string id_uph { get; set; }

        [Required]
        public string JenisTernakID { get; set; }
        [Required]
        public string JenisKomoditiID { get; set; }
        [Required]
        public string SatuanID { get; set; }

        [Required]
        public string TotalKebutuhan { get; set; }
        [Required]
        public IList<string> AsalBahanBakus { get; set; } = new List<string>();
        public string AsalBahanBaku { get; set; }

        [Required]
        public string Nilai { get; set; }

        public string CreatedBy { get; set; }

        public JenisTernakDTO JenisTernak { get; set; }
        public JenisKomoditiDTO JenisKomoditi { get; set; }
        public SatuanDTO Satuan { get; set; }
        public UphDTO Uph { get; set; }
    }
}
