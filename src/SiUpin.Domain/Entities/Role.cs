using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiUpin.Domain.Entities
{
    [Table("roles")]
    public class Role
    {
        public string RoleID { get; set; }

        public string Name { get; set; }

        public IList<User> Users { get; set; }

        public Role()
        {
            Users = new List<User>();
        }
    }
}