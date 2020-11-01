namespace SiUpin.Shared.Systems.Commands.SeedKelurahan
{
    public class KelurahanJSON
    {
        public string table { get; set; }
        public Row[] rows { get; set; }
    }

    public class Row
    {
        public string id_kelurahan { get; set; }
        public string id_kecamatan_fk { get; set; }
        public string nama_kelurahan { get; set; }
    }
}