﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiUpin.Domain.Entities
{
    [Table("produkolahans")]
    public class ProdukOlahan
    {
        public string ProdukOlahanID { get; set; }

        public string id_olahan { get; set; }

        public string JenisKomoditiID { get; set; }

        public string Name { get; set; }

        public JenisKomoditi JenisKomoditi { get; set; }

        public IList<UphProduk> UphProduks { get; set; }

        public ProdukOlahan()
        {
            UphProduks = new List<UphProduk>();

        }
    }
}