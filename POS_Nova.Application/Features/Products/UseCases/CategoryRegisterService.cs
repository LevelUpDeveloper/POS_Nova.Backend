using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using POS_Nova.Application.Common;
using POS_Nova.Application.Exceptions;
using POS_Nova.Application.Features.Products.DTOs;
using POS_Nova.Application.Interfaces.Persistence;
using POS_Nova.Application.Interfaces.Services;
using POS_Nova.Domain.Entities;



namespace POS_Nova.Application.Features.Products.UseCases
{
    public class CategoryRegisterService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICurrentUserService _currentUserService;

        public CategoryRegisterService(ICategoryRepository categoryRepository, ICurrentUserService currentUserService)
        {
            _categoryRepository = categoryRepository;
            _currentUserService = currentUserService;
        }

        public async Task<CategoryRegisterResponseDto> Execute(CategoryRegisterRequestDto categoryRegisterRequestDto)
        {
            //The category is normalized to avoid duplicates.
            string categoryNormalizer = await _categoryRepository.CategoryNormalizer(categoryRegisterRequestDto.Name);


            bool existCategory = await _categoryRepository.CategoryExists(categoryNormalizer);

            if (existCategory)
            {
                throw new ConflictException($"Ya se encuentra registrada la categoria: {categoryNormalizer}");
            }

            var category = Category.Create(categoryRegisterRequestDto.Name, categoryRegisterRequestDto.Description, categoryRegisterRequestDto.IsActive, DateTime.Now, _currentUserService.UserId);

            await _categoryRepository.CategoryCreateNew(category);

            return new CategoryRegisterResponseDto
            {
                Name = categoryNormalizer,
                Description = category.Description,
                IsActive = category.IsActive,
                AuditCreateDate = category.AuditCreateDate,
                AuditCreatedBy = _currentUserService.UserName
            };
        }

    }
}
