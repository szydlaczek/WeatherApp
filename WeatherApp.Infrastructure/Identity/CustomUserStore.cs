using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeatherApp.Domain.Entities;
using WeatherApp.Persistence.Context;

namespace WeatherApp.Infrastructure.Identity
{
    public class CustomUserStore : IUserStore<User>,
                                   IUserRoleStore<User>,
                                   IUserPasswordStore<User>    
    {
        #region Fields

        private readonly ApplicationDbContext _context;

        #endregion Fields

        #region Constructors        

        public CustomUserStore(ApplicationDbContext context)
        {
            this._context = context;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Tworzenie nowego użytkownika
        /// </summary>
        public async Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            
            await _context.Users.AddAsync(user);
            _context.SaveChanges();

            return IdentityResult.Success;
        }

        /// <summary>
        /// Aktualizacja danych bieżącego użytkownika
        /// </summary>
        public Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();

            return Task.FromResult(IdentityResult.Success);
        }

        /// <summary>
        /// Usunięcie wybranego użytkownika
        /// </summary>
        public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            _context.Users.Remove(user);
            _context.SaveChanges();

            return Task.FromResult(IdentityResult.Success);
        }

        public Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
            => Task.FromResult(_context.Users.Find(userId));

        public Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
            => Task.FromResult(_context.Users.Where(u => u.UserName == normalizedUserName).FirstOrDefault());

        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
            => Task.FromResult(user.Id.ToString());

        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
            => Task.FromResult(user.UserName);

        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            user.UserName=userName;
            _context.SaveChanges();

            return Task.CompletedTask;
        }

        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
            => Task.FromResult(user.UserName);

        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
            => Task.CompletedTask;

        public async Task AddToRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user cannot be null");
            }

            if (string.IsNullOrEmpty(roleName))
            {
                throw new ArgumentNullException("Argument cannot be null or empty: roleName.");
            }

            var findRole = await _context.Roles
                .Where(r => string.Equals(r.Name,roleName, StringComparison.OrdinalIgnoreCase))
                .FirstOrDefaultAsync();

            if (findRole != null)
            {
                _context.UserRoles.Add(new UserRole() {User=user, Role=findRole });                
            }

            await _context.SaveChangesAsync();
            
        }

        public async Task RemoveFromRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            var findRole = _context.Roles.Where(r => r.Name == roleName).FirstOrDefault();
            if (findRole != null)
            {
                _context.UserRoles.Remove(user.UserRoles.Where(ur => ur.RoleId == findRole.Id).FirstOrDefault());
                await _context.SaveChangesAsync();
            }

            
        }

        public Task<IList<string>> GetRolesAsync(User user, CancellationToken cancellationToken)
            => Task.FromResult((IList<string>)user.UserRoles.Select(ur => ur.Role).Select(r => r.Name).ToList());

        public Task<bool> IsInRoleAsync(User user, string roleName, CancellationToken cancellationToken)
            => Task.FromResult(user.UserRoles.Select(ur => ur.Role.Name).Contains(roleName));

        public Task<IList<User>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            if (String.IsNullOrEmpty(roleName))
            {
                throw new ArgumentNullException("roleName");
            }

            return Task.FromResult((IList<User>)(_context.UserRoles
                .Include(ur => ur.Role)
                .Include(ur => ur.User)
                .Where(ur => ur.Role.Name == roleName)
                .Select(ur => ur.User)
                .ToList()));
        }

        public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            user.Password = passwordHash;

            return Task.CompletedTask;
        }

        public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
            => Task.FromResult(user.Password);

        public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            var hasPassword = !string.IsNullOrEmpty(user.Password);

            return Task.FromResult(hasPassword);
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();                
            }
        }

        

        #endregion Methods
    }
}
