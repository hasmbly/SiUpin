using System.ComponentModel.DataAnnotations.Schema;

namespace SiUpin.Domain.Entities
{
    [Table("asalbantuans")]
    public class AsalBantuan
    {
        public string AsalBantuanID { get; set; }

        public string Name { get; set; }
    }
}