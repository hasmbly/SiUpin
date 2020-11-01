namespace SiUpin.Shared.Systems.Commands.SeedBerita
{
    public class BeritaJSON
    {
        public string table { get; set; }
        public Row[] rows { get; set; }
    }

    public class Row
    {
        public string id_berita { get; set; }
        public string judul { get; set; }
        public string tanggal { get; set; }
        public string penulis { get; set; }
        public string uraian { get; set; }
        public string foto { get; set; }
    }
}