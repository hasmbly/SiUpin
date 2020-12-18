using System.ComponentModel.DataAnnotations.Schema;
using SiUpin.Domain.Common;

namespace SiUpin.Domain.Entities
{
    [Table("files")]
    public class File : AuditableEntity
    {
        public string FileID { get; set; }
        public string EntityID { get; set; }
        public string EntityType { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}