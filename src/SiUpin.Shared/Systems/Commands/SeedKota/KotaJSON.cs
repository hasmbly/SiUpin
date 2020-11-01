namespace SiUpin.Shared.Systems.Commands.SeedKota
{
    public class KotaJSON
    {
        public string table { get; set; }
        public Row[] rows { get; set; }
    }

    public class Row
    {
        public string id_kota { get; set; }
        public string id_provinsi_fk { get; set; }
        public string nama_kota { get; set; }
    }
}