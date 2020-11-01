using SiUpin.Domain.Common;

namespace SiUpin.Domain.Entities
{
    public class Pesan : AuditableEntity
    {
        public string PesanID { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
    }
}