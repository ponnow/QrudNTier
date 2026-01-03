using Microsoft.AspNetCore.Mvc;
using QrudNTier.BLL.Implementations;
using QrudNTier.BLL.Interfaces;

namespace QrudNTier.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            var product = new Model.Product
            {
                Name = "Sample Product",
                Description = "This is a sample product.",
                Price = 9.99M
            };

            _productService.AddAsync(product);
            return View();
        }
    }
}
