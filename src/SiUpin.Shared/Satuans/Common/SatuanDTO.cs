using System.ComponentModel.DataAnnotations;

namespace SiUpin.Shared.Satuans.Common
{
    public class SatuanDTO
    {
        public string SatuanID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
