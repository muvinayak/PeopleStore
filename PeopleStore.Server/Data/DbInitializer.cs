using PeopleStore.Server.Models;

namespace PeopleStore.Server.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if(context.Categories.Any())
            {
                return;
            }

            var categories = new Category[]
            {
                new() { Name = "Clothing"},
                new() { Name = "Footwear"},
                new() { Name = "Home"},
                new() { Name = "Luggage"}
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();
        }
    }
}
