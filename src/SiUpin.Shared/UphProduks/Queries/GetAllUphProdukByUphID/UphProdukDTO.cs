namespace SiUpin.Shared.UphProduks.Queries.GetAllUphProdukByUphID
{
    public class UphProdukDTO
    {
        public string UphProdukID { get; set; }

        public string UrlOriginPhoto { get; set; }

        public string Name { get; set; }
        public string Harga { get; set; }

#pragma warning disable CS8632
        public string? Provinsi { get; set; }
    }
}