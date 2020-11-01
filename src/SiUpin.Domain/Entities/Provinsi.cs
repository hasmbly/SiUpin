﻿using System.Collections.Generic;

namespace SiUpin.Domain.Entities
{
    public class Provinsi
    {
        public string ProvinsiID { get; set; }

        public string id_provinsi { get; set; }

        public string Name { get; set; }

        public IList<Kota> Kotas { get; set; }
        public IList<User> Users { get; set; }
        public IList<Uph> Uphs { get; set; }

        public Provinsi()
        {
            Kotas = new List<Kota>();
            Users = new List<User>();
            Uphs = new List<Uph>();
        }
    }
}