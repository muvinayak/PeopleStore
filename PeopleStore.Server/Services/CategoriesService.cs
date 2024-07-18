using Microsoft.EntityFrameworkCore;
using PeopleStore.Server.Data;
using PeopleStore.Server.Models;

namespace PeopleStore.Server.Services
{
    public class CategoriesService(ApplicationDbContext context)
    {
        private readonly ApplicationDbContext _applicationDbContext = context;

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _applicationDbContext.Categories
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
