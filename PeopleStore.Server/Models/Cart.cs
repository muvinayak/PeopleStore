namespace PeopleStore.Server.Models
{
    public class Cart
    {
        public int UserId { get; set; }
        public Dictionary<long, int> CheckedOutProducts {  get; set; }
        public Cart()
        {
            CheckedOutProducts = [];
        }
        public void AddProduct(long productId, int quantity)
        {
            CheckedOutProducts.Add(productId, quantity);
        }
    }
}
