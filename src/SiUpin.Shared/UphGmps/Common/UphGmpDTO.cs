using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SiUpin.Shared.Uphs.Common;

namespace SiUpin.Shared.UphGmps.Common
{
    public class UphGmpDTO
    {
        public string UphGmpID { get; set; }

        [Required]
        public string UphID { get; set; }

        public int No { get; set; }
        public string id_gmp { get; set; }
        public string id_uph { get; set; }

        [Required]
        public IList<string> nama_gmps { get; set; } = new List<string>();
        public string nama_gmp { get; set; }

        public string jml_gmp { get; set; }
        public string user { get; set; }

        public UphDTO Uph { get; set; }
    }
}
