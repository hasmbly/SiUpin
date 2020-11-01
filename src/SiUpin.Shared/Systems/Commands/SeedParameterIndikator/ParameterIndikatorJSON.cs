namespace SiUpin.Shared.Systems.Commands.SeedParameterIndikator
{
    public class ParameterIndikatorJSON
    {
        public string table { get; set; }
        public Row[] rows { get; set; }
    }

    public class Row
    {
        public string id_indikator { get; set; }
        public string id_kriteria { get; set; }
        public string nama_indikator { get; set; }
    }
}