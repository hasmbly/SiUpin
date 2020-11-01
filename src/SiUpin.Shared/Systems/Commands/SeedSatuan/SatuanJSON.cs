namespace SiUpin.Shared.Systems.Commands.SeedSatuan
{
    public class SatuanJSON
    {
        public string table { get; set; }
        public Row[] rows { get; set; }
    }

    public class Row
    {
        public string id_satuan { get; set; }
        public string nama_satuan { get; set; }
    }
}
