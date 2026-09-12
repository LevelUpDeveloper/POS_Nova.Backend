using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using POS_Nova.Application.Features.Auth.DTOs;
using POS_Nova.Application.Common;
using POS_Nova.Application.Interfaces.Persistence;
using POS_Nova.Domain.Entities;
using POS_Nova.Infrastructure.DataPersistence;
using POS_Nova.Infrastructure.Services;


namespace POS_Nova.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            
        }

        public async Task<string> CategoryNormalizer(string categoryName)
        {
            string categoryStandardized = TextNormalizer.FormatName(categoryName);
            return categoryStandardized;
        }

        public async Task<bool> CategoryExists(string categoryName)
        {
            bool exist = await _appDbContext.Category
                .AnyAsync(c => c.Name == categoryName);
            
            return exist;
        }


        public async Task<Category> CategoryCreateNew(Category category)
        {
            await _appDbContext.Category.AddAsync(category);
            await _appDbContext.SaveChangesAsync();
            return category;
        }


    }
}
