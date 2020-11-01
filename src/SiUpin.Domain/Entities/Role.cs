using System.Collections.Generic;

namespace SiUpin.Domain.Entities
{
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