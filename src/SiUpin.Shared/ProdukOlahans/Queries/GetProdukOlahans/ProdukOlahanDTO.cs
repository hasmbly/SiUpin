using SiUpin.Shared.JenisKomiditis.Common.GetAllJenisKomiditi;

namespace SiUpin.Shared.ProdukOlahans.Queries.GetProdukOlahans
{
    public class ProdukOlahanDTO
    {
        public int No { get; set; }
        public string ProdukOlahanID { get; set; }
        public string Name { get; set; }
        public JenisKomoditiDTO JenisKomoditi { get; set; }
    }
}
