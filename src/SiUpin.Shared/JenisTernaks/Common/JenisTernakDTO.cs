using System.ComponentModel.DataAnnotations;

namespace SiUpin.Shared.JenisTernaks.Queries.Common
{
    public class JenisTernakDTO
    {
        public int No { get; set; }
        public string JenisTernakID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
