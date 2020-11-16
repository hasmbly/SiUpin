namespace SiUpin.Shared.Uphs.Queries.GetAllUph
{
    public class UphDTO
    {
        public string UphID { get; set; }

        public string Name { get; set; }

#pragma warning disable CS8632
        public string? Provinsi { get; set; }
        public string? Kota { get; set; }

        public string Ketua { get; set; }
        public string Handphone { get; set; }
        public string Alamat { get; set; }
    }
}
