using System.ComponentModel.DataAnnotations.Schema;

namespace SiUpin.Domain.OldEntities
{
    [Table("tb_uph")]
    public class Uph
    {
        #region Uph's Properties
        public string id_uph { get; set; }
        public string nama_uph { get; set; }
        public string nama_ketua { get; set; }
        public string no_hp { get; set; }

        public string provinsi { get; set; }
        public string kabupaten { get; set; }
        public string kecamatan { get; set; }
        public string desa { get; set; }

        public string alamat { get; set; }
        public string tahun_berdiri { get; set; }
        #endregion

        #region UphProduk
        public string produk_olahan { get; set; } // produkOlahan
        public string jenis_komoditi { get; set; } // not neccessary, already included in produkOlahan
        public string merk { get; set; } // or name of produkOlahan
        public string spesies { get; set; } // or jenisTernak
        public string ket_produk { get; set; }
        #endregion

        public string bentuk_lembaga { get; set; } // parameter cluster: Kelembagaan -> Kelembagaan -> Bentuk kelembagaan
        public string badan_hukum { get; set; } // parameter cluster: Kelembagaan -> Kelembagaan -> Badan hukum
        public string status_uph { get; set; } // parameter cluster: Kelembagaan -> Kapasitas kelembagaan -> Status UPH
        public string administrasi { get; set; } // parameter cluster: Kelembagaan -> Kapasitas kelembagaan -> Administrasi kegiatan dan keuangan

        public string foto { get; set; } // produkOlahan to file
    }
}
