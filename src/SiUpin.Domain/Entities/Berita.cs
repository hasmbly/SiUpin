using System.ComponentModel.DataAnnotations.Schema;
using SiUpin.Domain.Common;

namespace SiUpin.Domain.Entities
{
    [Table("beritas")]
    public class Berita : AuditableEntity
    {
        public string BeritaID { get; set; }

        public string id_berita { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
    }
}