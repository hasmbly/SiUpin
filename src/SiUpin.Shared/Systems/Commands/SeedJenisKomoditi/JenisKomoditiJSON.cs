namespace SiUpin.Shared.Systems.Commands.SeedJenisKomoditi
{
    public class JenisKomoditiJSON
    {
        public string table { get; set; }
        public Row[] rows { get; set; }
    }

    public class Row
    {
        public string id_komoditi { get; set; }
        public string nama_komoditi { get; set; }
    }
}