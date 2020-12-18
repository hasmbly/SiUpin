using System.ComponentModel.DataAnnotations;

namespace SiUpin.Shared.Uphs.Common
{
    public class UphDTO
    {
        public string UphID { get; set; }

        [Required]
        public string ProvinsiID { get; set; }
        public string KotaID { get; set; }
        public string KecamatanID { get; set; }
        public string KelurahanID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Ketua { get; set; }

        [Required]
        public string Handphone { get; set; }
        public string Alamat { get; set; }
        public string TahunBerdiri { get; set; }
    }
}
