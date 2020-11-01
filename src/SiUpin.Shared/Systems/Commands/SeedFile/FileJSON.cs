namespace SiUpin.Shared.Systems.Commands.SeedFile
{
    public class FileJSON
    {
        public Row[] rows { get; set; }
    }

    public class Row
    {
        public string entity_id { get; set; }
        public string entity_type { get; set; }
        public string name { get; set; }
    }
}