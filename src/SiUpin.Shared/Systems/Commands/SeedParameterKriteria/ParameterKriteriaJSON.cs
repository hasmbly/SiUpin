namespace SiUpin.Shared.Systems.Commands.SeedParameterKriteria
{
    public class ParameterKriteriaJSON
    {
        public string table { get; set; }
        public Row[] rows { get; set; }
    }

    public class Row
    {
        public string id_kriteria { get; set; }
        public string id_aspek { get; set; }
        public string nama_kriteria { get; set; }
    }
}