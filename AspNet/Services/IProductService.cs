using AspNet.Models;

namespace AspNet.Services
{
    public interface IProductService
    {
        // using our Product.cs model
        List<Product> GetProducts();
    }
}
