namespace SiUpin.Shared.Uphs.Queries.GetUph
{
    public class UphDTO
    {
        public string UphID { get; set; }

        public string Name { get; set; }

        public string Provinsi { get; set; }
        public string Kota { get; set; }
        public string Kecamatan { get; set; }
        public string Kelurahan { get; set; }

        public string Ketua { get; set; }
        public string Handphone { get; set; }
        public string Alamat { get; set; }
        public string TahunBerdiri { get; set; }
    }
}
