using System;
using System.ComponentModel.DataAnnotations;

namespace SiUpin.Shared.Beritas.Common
{
    public class BeritaDTO
    {
        public int No { get; set; }
        public string BeritaID { get; set; }

        [Required]
        public string Title { get; set; }

        public string UserID { get; set; }
        public string UserName { get; set; }

        public string Description { get; set; }
        public string UrlOriginPhoto { get; set; }

        public DateTimeOffset Created { get; set; }
    }
}
