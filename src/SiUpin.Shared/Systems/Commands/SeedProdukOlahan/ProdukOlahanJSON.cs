namespace SiUpin.Shared.Systems.Commands.SeedProdukOlahan
{
    public class ProdukOlahanJSON
    {
        public string table { get; set; }
        public Row[] rows { get; set; }
    }

    public class Row
    {
        public string id_olahan { get; set; }
        public string nama_olahan { get; set; }
        public string id_komoditi_fk { get; set; }
    }
}