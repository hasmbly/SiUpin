using System.Collections.Generic;

namespace SiUpin.Shared.EntityHelper.BahanBaku
{
    public class BahanBaku
    {
        public IDictionary<string, string> BahanBakuAsal { get; set; }

        public BahanBaku()
        {
            BahanBakuAsal = new Dictionary<string, string>()
            {
                {"1", "Dari Peternakan UPH"},
                {"2", "Membeli dari Pihak Lain"}
            };
        }
    }
}
