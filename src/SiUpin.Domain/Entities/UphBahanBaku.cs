using System.ComponentModel.DataAnnotations.Schema;
using SiUpin.Domain.Common;

namespace SiUpin.Domain.Entities
{
    [Table("uphbahanbakus")]
    public class UphBahanBaku : AuditableEntity
    {
        public string UphBahanBakuID { get; set; }
        public string UphID { get; set; }

        public string id_bahan_baku { get; set; }
        public string id_uph { get; set; }

        public string JenisTernakID { get; set; }
        public string JenisKomoditiID { get; set; }
        public string SatuanID { get; set; }

        public string TotalKebutuhan { get; set; }
        public string AsalBahanBaku { get; set; }
        public string Nilai { get; set; }

        public JenisTernak JenisTernak { get; set; }
        public JenisKomoditi JenisKomoditi { get; set; }
        public Satuan Satuan { get; set; }
        public Uph Uph { get; set; }
    }
}
