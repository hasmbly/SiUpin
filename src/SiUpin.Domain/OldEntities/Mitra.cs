﻿using System.ComponentModel.DataAnnotations.Schema;

namespace SiUpin.Domain.OldEntities
{
    [Table("tb_mitra")]
    public class Mitra
    {
        public string id_mitra { get; set; }
        public string id_uph { get; set; }
        public string bermitra { get; set; }
        public string jenis_usaha { get; set; }
        public string nama_perusahaan { get; set; }
        public string alamat { get; set; }
        public string penanggungjawab { get; set; }
        public string no_hp { get; set; }
        public string jenis_mitra { get; set; }
        public string lembaga { get; set; }
        public string lembaga_lain { get; set; }
        public string nilai_lembaga { get; set; }
        public string nilai_mitra { get; set; }
        public string detail_bahan { get; set; }
        public string lain_kopetensi { get; set; }
        public string satuan_bahan { get; set; }
        public string detail_mitra { get; set; }
        public string detail_sarana { get; set; }
        public string nilai_sarana { get; set; }
        public string detail_kopetensi { get; set; }
        public string detail_fasilitasi { get; set; }
        public string detail_promosi { get; set; }
        public string nilai_promosi { get; set; }
        public string manajemen_limbah { get; set; }
        public string sasaran { get; set; }
        public string perjanjian { get; set; }
        public string upload_doc { get; set; }
        public string awal_periode { get; set; }
        public string akhir_periode { get; set; }
        public string status { get; set; }
        public string user { get; set; }
    }
}
