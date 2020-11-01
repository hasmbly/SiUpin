namespace SiUpin.Shared.Systems.Commands.SeedParameterAspek
{
    public class ParameterAspekJSON
    {
        public string table { get; set; }
        public Row[] rows { get; set; }
    }

    public class Row
    {
        public string id_aspek { get; set; }
        public string nama_aspek { get; set; }
    }
}