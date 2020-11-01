namespace SiUpin.Shared.Systems.Commands.SeedJenisTernak
{
    public class JenisTernakJSON
    {
        public string table { get; set; }
        public Row[] rows { get; set; }
    }

    public class Row
    {
        public string id_ternak { get; set; }
        public string nama_ternak { get; set; }
    }
}