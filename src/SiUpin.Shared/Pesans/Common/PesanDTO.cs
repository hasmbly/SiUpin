using System.ComponentModel.DataAnnotations;

namespace SiUpin.Shared.Pesans.Queries.Common
{
    public class PesanDTO
    {
        public string PesanID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
