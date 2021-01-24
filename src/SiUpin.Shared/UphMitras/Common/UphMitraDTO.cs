using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SiUpin.Shared.Uphs.Common;

namespace SiUpin.Shared.UphMitras.Common
{
    public class UphMitraDTO
    {
        public string UphMitraID { get; set; }

        public int No { get; set; }
        public string id_mitra { get; set; }
        public string id_uph { get; set; }

        public string penanggungjawab { get; set; }
        public string no_hp { get; set; }
        public string awal_periode { get; set; }
        public string akhir_periode { get; set; }
        //public string upload_doc { get; set; } // unused

        [Required]
        public string UphID { get; set; }

        [Required]
        public string bermitra { get; set; }

        [Required]
        public string jenis_usaha { get; set; }

        [Required]
        public string nama_perusahaan { get; set; }

        [Required]
        public string alamat { get; set; }

        [Required]
        public string status { get; set; }

        public string user { get; set; }

        [Required]
        public IList<string> lembagas { get; set; } = new List<string>();
        public string lembaga { get; set; }
        public string lembaga_lain { get; set; }
        public string nilai_lembaga { get; set; } // Cluster UPH

        [Required]
        public IList<string> jenis_mitras { get; set; } = new List<string>();
        public string jenis_mitra { get; set; } // Cluster
        public string nilai_mitra { get; set; } // Cluster UPH
        //public string detail_mitra { get; set; } // unused

        public string satuan_bahan { get; set; }
        public string detail_bahan { get; set; }

        //public string lain_kopetensi { get; set; } // unused
        public string detail_kopetensi { get; set; } // Cluster

        public IList<string> detail_saranas { get; set; } = new List<string>();
        public string detail_sarana { get; set; }
        public string nilai_sarana { get; set; } // Cluster

        public IList<string> detail_fasilitasis { get; set; } = new List<string>();
        public string detail_fasilitasi { get; set; } // Cluster

        public IList<string> detail_promosis { get; set; } = new List<string>();
        public string detail_promosi { get; set; }
        public string nilai_promosi { get; set; } // Cluster

        public string manajemen_limbah { get; set; } // Cluster

        [Required]
        public string sasaran { get; set; } // Cluster

        [Required]
        public string perjanjian { get; set; } // Cluster

        public UphDTO Uph { get; set; }
    }
}
