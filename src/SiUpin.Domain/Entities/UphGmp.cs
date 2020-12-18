using System.ComponentModel.DataAnnotations.Schema;
using SiUpin.Domain.Common;

namespace SiUpin.Domain.Entities
{
    [Table("uphgmps")]
    public class UphGmp : AuditableEntity
    {
        public string UphGmpID { get; set; }
        public string UphID { get; set; }

        public string id_gmp { get; set; }
        public string id_uph { get; set; }
        public string nama_gmp { get; set; }
        public string jml_gmp { get; set; }
        public string user { get; set; }
    }
}
