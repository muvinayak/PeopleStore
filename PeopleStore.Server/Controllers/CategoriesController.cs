using Microsoft.AspNetCore.Mvc;
using PeopleStore.Server.Models;
using PeopleStore.Server.Services;

namespace PeopleStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoriesService _categoriesService;

        public CategoriesController(CategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> Index()
        {
            return await _categoriesService.GetCategories();
        }
    }
}
