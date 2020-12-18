using System.ComponentModel.DataAnnotations.Schema;

namespace SiUpin.Domain.OldEntities
{
    [Table("tb_bahan_baku")]
    public class BahanBaku
    {
        public string id_bahan_baku { get; set; }
        public string id_uph { get; set; }
        public string jenis_ternak { get; set; }
        public string bahan_utama { get; set; }
        public string kebutuhan { get; set; }
        public string satuan { get; set; }
        public string asal { get; set; }
        public string nilai { get; set; }
        public string user { get; set; }
    }
}
