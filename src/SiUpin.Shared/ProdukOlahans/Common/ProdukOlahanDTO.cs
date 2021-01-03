using System.ComponentModel.DataAnnotations;

namespace SiUpin.Shared.ProdukOlahans.Common
{
    public class ProdukOlahanDTO
    {
        public string ProdukOlahanID { get; set; }

        [Required]
        public string JenisKomoditiID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
