using System.ComponentModel.DataAnnotations;

namespace PeopleStore.Server.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public IList<Product>? Products { get; set; }
    }
}