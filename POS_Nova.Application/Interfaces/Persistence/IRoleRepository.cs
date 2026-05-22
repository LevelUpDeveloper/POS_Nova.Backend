using POS_Nova.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Nova.Application.Interfaces.Persistence
{
    public interface IRoleRepository
    {
        Task<Role> GetByName(string name);

        Task<bool> ExistByName(string name);
        Task<Role> CreateAsync(Role role);
    }
}
