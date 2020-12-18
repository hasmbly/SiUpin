using System.ComponentModel.DataAnnotations;

namespace SiUpin.Shared.UphProduks.Command.CreateUphProduk
{
    public class UphProdukDTO
    {
        public string UphID { get; set; }

#pragma warning disable CS8632
        public string? ProdukOlahanID { get; set; }
        public string? JenisTernakID { get; set; }
        public string? SatuanID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Harga { get; set; }

        public int Berat { get; set; }
        public string Description { get; set; }
    }
}
