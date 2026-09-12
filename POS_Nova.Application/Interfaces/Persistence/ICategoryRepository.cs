using POS_Nova.Application.Features.Auth.DTOs;
using POS_Nova.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Nova.Application.Interfaces.Persistence
{
    public interface ICategoryRepository
    {
        Task<string> CategoryNormalizer(string categoryName);

        Task<bool> CategoryExists(string categoryName);

        Task<Category> CategoryCreateNew(Category category);
    }
}
