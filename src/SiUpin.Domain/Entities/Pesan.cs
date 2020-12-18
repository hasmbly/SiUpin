using System.ComponentModel.DataAnnotations.Schema;
using SiUpin.Domain.Common;

namespace SiUpin.Domain.Entities
{
    [Table("pesans")]
    public class Pesan : AuditableEntity
    {
        public string PesanID { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
    }
}