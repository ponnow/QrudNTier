using Microsoft.AspNetCore.Mvc;
using QrudNTier.BLL.Implementations;
using QrudNTier.BLL.Interfaces;
using QrudNTier.Model;

namespace QrudNTier.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productService.AddAsync(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productService.UpdateAsync(product);
                return RedirectToAction("Index");
            }
            return View(product);

        }
    }
}
