namespace SiUpin.Shared.Systems.Commands.SeedKecamatan
{
    public class RoleSON
    {
        public string table { get; set; }
        public Row[] rows { get; set; }
    }

    public class Row
    {
        public string id_kecamatan { get; set; }
        public string id_kota_fk { get; set; }
        public string nama_kecamatan { get; set; }
    }
}