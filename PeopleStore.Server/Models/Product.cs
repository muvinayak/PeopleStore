using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace PeopleStore.Server.Models
{
    public class Product
    {
        public long Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public int CategoryId {  get; set; }
        public string? OwnerId { get; set; }
        public IdentityUser? Owner { get; set; }
        public Category? Category { get; set; }
        public decimal? UnitPrice { get; set; }
        public int Quantity {  get; set; }
    }
}
