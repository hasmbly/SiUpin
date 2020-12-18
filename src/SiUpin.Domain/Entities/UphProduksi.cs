using System.ComponentModel.DataAnnotations.Schema;
using SiUpin.Domain.Common;

namespace SiUpin.Domain.Entities
{
    [Table("uphproduksis")]
    public class UphProduksi : AuditableEntity
    {
        public string UphProduksiID { get; set; }
        public string UphID { get; set; }

        public string id_produksi { get; set; }
        public string id_uph { get; set; }
        public string nama_uph { get; set; }
        public string bahan_baku { get; set; }
        public string jml_produksi { get; set; }
        public string satuan { get; set; }
        public string izin_edar { get; set; }
        public string jml_edar { get; set; }
        public string sertifikat { get; set; }
        public string jml_sertifikat { get; set; }
        public string gmp { get; set; }
        public string jml_gmp { get; set; }
        public string jml_hari_produksi { get; set; }
        public string user { get; set; }

        public Uph Uph { get; set; }
    }
}
