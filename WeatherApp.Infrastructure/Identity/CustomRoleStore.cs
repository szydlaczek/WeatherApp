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
    public class CustomRoleStore : IRoleStore<Role>
    {
        #region Fields

        private ApplicationDbContext _context;

        #endregion Fields

        #region Constructors        

        public CustomRoleStore(ApplicationDbContext context)
        {
            this._context = context;
        }

        #endregion Constructors

        public async Task<IdentityResult> CreateAsync(Role role, CancellationToken cancellationToken)
        {
            if (role == null)
            {
                throw new ArgumentNullException("role");
            }

            _context.Roles.Add(role);
            await _context.SaveChangesAsync();

            return IdentityResult.Success;
        }

        public Task<IdentityResult> DeleteAsync(Role role, CancellationToken cancellationToken)
        {
            if (role == null)
            {
                throw new ArgumentNullException("role");
            }

            _context.Roles.Remove(role);
            _context.SaveChanges();

            return Task.FromResult(IdentityResult.Success);
        }

        public Task<Role> FindByIdAsync(string roleId, CancellationToken cancellationToken)
            => Task.FromResult(_context.Roles.Find(roleId));

        public Task<Role> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
            => Task.FromResult(_context.Roles.Where(r => r.Name == normalizedRoleName).FirstOrDefault());

        public Task<IdentityResult> UpdateAsync(Role role, CancellationToken cancellationToken)
        {
            if (role == null)
            {
                throw new ArgumentNullException("role");
            }

            _context.Entry(role).State = EntityState.Modified;
            _context.SaveChanges();

            return Task.FromResult(IdentityResult.Success);
        }

        public Task<string> GetNormalizedRoleNameAsync(Role role, CancellationToken cancellationToken)
            => Task.FromResult(role.Name);

        public Task<string> GetRoleIdAsync(Role role, CancellationToken cancellationToken)
            => Task.FromResult(role.Id);

        public Task<string> GetRoleNameAsync(Role role, CancellationToken cancellationToken)
            => Task.FromResult(role.Name);

        public async Task SetNormalizedRoleNameAsync(Role role, string normalizedName, CancellationToken cancellationToken)
        {
            if (role == null)
            {
                throw new ArgumentNullException("role");
            }

            role.Name = normalizedName;
            await _context.SaveChangesAsync();

            
        }

        public async Task SetRoleNameAsync(Role role, string roleName, CancellationToken cancellationToken)
        {
            if (role == null)
            {
                throw new ArgumentNullException("role");
            }

            role.Name = roleName;
            await _context.SaveChangesAsync();            
        }

        public void Dispose()
        {
        }
    }
}
