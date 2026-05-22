using Microsoft.EntityFrameworkCore;
using POS_Nova.Application.Interfaces.Persistence;
using POS_Nova.Domain.Entities;
using POS_Nova.Infrastructure.DataPersistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Nova.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Role> GetByName(string name)
        {
            return await _context.Role
                .FirstOrDefaultAsync(r => r.Name == name);
        }

        public async Task<Role> CreateAsync(Role role)
        {
            await _context.Role.AddAsync(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<bool> ExistByName(string name)
        {
            return await _context.Role.AnyAsync(r => r.Name == name);
        }
    }
}
