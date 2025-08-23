using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Sooqak.Context;
using Sooqak.DTO.CategoryDTO.Input;
using Sooqak.DTO.CategoryDTO.Output;
using Sooqak.Entities;
using Sooqak.Interface;


namespace Sooqak.Services
{
    public class CategoryService : ICategory
    {
        private readonly SooqakDbContext _context;
        public CategoryService(SooqakDbContext context)
        {
            _context = context;
        }
        public async Task<string> AddCategory(AddCategoryInputDTO input)
        {
            try
            {
                bool exists = await _context.categories
                    .AnyAsync(c => c.CategoryType == input.CategoryType);

                if (exists)
                    return "Category already exist";

                Category category = new Category()
                {
                    CategoryType = input.CategoryType,
                    Description = input.Description,
                    Icon = input.Icon,
                    CreationDate = DateTime.Now,
                    CreatedBy = "Admin"
                };
                
                if (category == null)
                    return "Some thing went wrong";

                await _context.categories.AddAsync(category);
                await _context.SaveChangesAsync();
                return "Category Created Successfully";
                
            }
            catch 
            {
                throw new Exception("Something went wrong");
            }
        }


        public async Task<GetCategoryOutputDTO> UpdateCategory(UpdateCategoryInputDTO input)
        {
            try
            {
                var category = _context.categories.Where(x => x.Id == input.Id).FirstOrDefault();
                if (category == null)
                {
                    throw new Exception("Category Not Found");
                }

                if (input.CategoryType.HasValue)
                    category.CategoryType = input.CategoryType.Value;

                if (!string.IsNullOrEmpty(input.Description))
                    category.Description = input.Description;

                if (!string.IsNullOrEmpty(input.Icon))
                    category.Icon = input.Icon;

                _context.Update(category);
                await _context.SaveChangesAsync();

                return new GetCategoryOutputDTO
                {
                    Id = category.Id,
                    CategoryType = category.CategoryType,
                    Description = category.Description,
                    Icon = category.Icon
                };
            }
            catch 
            {
                throw new Exception("Something went wrong");
            }
        }

        public async Task<string> DeleteCategory(int Id)
        {
            try
            {
                if (Id == 0)
                    return "Invalid Category";
                var category = await _context.categories.Where(x => x.Id == Id).SingleOrDefaultAsync();
                if (category == null)
                    return "Category Not Found";
                _context.categories.Remove(category);
                await _context.SaveChangesAsync();
                return "Category Deleted Successfully";
                
            }
            catch 
            {
                throw new Exception("Something went wrong");
            }
        }

        public async Task<List<GetCategoryOutputDTO>> GetAllCategories()
        {
            try
            {
                var category = await _context.categories.Select(x => new GetCategoryOutputDTO
                {
                    Id = x.Id,
                    CategoryType = x.CategoryType,
                    Description = x.Description,
                    Icon = x.Icon
                }).ToListAsync();
                return category;
            }
            catch 
            {
                throw new Exception("Something went wrong");
            }
        }

        public async Task<GetCategoryOutputDTO> GetCategoryById(int Id)
        {
            try
            {
                if (Id == 0)
                    throw new Exception("Invalid Category");
                var category = await _context.categories.Where(x => x.Id == Id).SingleOrDefaultAsync();
                if (category == null)
                    throw new Exception("Category not found");
                return new GetCategoryOutputDTO
                {
                    Id = Id,
                    CategoryType = category.CategoryType,
                    Description = category.Description,
                    Icon = category.Icon
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong");
            }
        }

        
    }
}
