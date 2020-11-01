namespace SiUpin.Shared.Systems.Commands.SeedAsalBantuan
{
    public class AsalBantuanJSON
    {
        public string table { get; set; }
        public Row[] rows { get; set; }
    }

    public class Row
    {
        public string id_asal_bantuan { get; set; }
        public string nama_asal_bantuan { get; set; }
    }
}