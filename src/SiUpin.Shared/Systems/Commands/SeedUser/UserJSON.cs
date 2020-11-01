namespace SiUpin.Shared.Systems.Commands.SeedUser
{
    public class UserJSON
    {
        public string table { get; set; }
        public Row[] rows { get; set; }
    }

    public class Row
    {
        public string id { get; set; }
        public string username { get; set; }
        public string nama { get; set; }
        public string pass { get; set; }
        public string level { get; set; }
        public string email { get; set; }
        public string alamat { get; set; }
        public string provinsi { get; set; }
        public string kota { get; set; }
        public string kecamatan { get; set; }
        public string desa { get; set; }
        public string jabatan { get; set; }
        public string nip { get; set; }
        public string instansi { get; set; }
        public string telpon { get; set; }
        public string foto { get; set; }
    }
}