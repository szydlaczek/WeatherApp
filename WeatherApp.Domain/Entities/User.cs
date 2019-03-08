using System.Collections.Generic;

namespace WeatherApp.Domain.Entities
{
    public class User
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}