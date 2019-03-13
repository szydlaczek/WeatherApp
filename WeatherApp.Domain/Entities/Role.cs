using System.Collections.Generic;

namespace WeatherApp.Domain.Entities
{
    public class Role
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public string Id { get; set; }

        public string Name { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}