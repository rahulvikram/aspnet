using AspNet.Models;

namespace AspNet.Services
{
    public class ProductService : IProductService
    {
        // GetProducts method returns a list of products for our marketplace
        // returns a list of Product objects, as defined in Product.cs model
        public List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", ImageUrl = "https://via.placeholder.com/200", Price = 25.99m },
                new Product { Id = 2, Name = "Product 2", ImageUrl = "https://via.placeholder.com/200", Price = 35.00m },
                new Product { Id = 3, Name = "Product 3", ImageUrl = "https://via.placeholder.com/200", Price = 49.00m }
            };
        }
    }
}
