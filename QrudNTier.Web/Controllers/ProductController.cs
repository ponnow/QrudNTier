using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            return View(products.Data);
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

        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            return View(product.Data);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await _productService.GetByIdAsync(id);

            if (result.Data == null)
            {
                return NotFound();
            }

            return View(result.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productService.UpdateAsync(product);
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }
    }
}
