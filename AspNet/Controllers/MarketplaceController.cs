using AspNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNet.Controllers
{
    public class MarketplaceController : Controller
    {
        // constructor and dependency injection for ProductService
        private readonly IProductService _productService;
        public MarketplaceController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: /Marketplace
        [HttpGet("Marketplace")]
        public IActionResult Marketplace()
        {
            // retrieve our products from the ProductService and return it to the view
            var products = _productService.GetProducts();
            return View(products);
        }
    }
}
