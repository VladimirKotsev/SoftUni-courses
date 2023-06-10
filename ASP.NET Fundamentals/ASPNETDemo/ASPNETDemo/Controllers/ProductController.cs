namespace ASPNETDemo.Controllers
{
    using System.Text.Json;
    using System.Text;

    using Microsoft.AspNetCore.Mvc;

    using ASPNETDemo.Models;
    using Microsoft.Net.Http.Headers;

    public class ProductController : Controller
    {
        private IEnumerable<ProductViewModel> _products = new List<ProductViewModel>()
        {
            new ProductViewModel
            {
                Id = 1,
                Name = "Cheese",
                Price = 7.00
            },
            new ProductViewModel
            {
                Id = 2,
                Name = "Ham",
                Price = 5.50
            },
            new ProductViewModel
            {
                Id = 3,
                Name = "Bread",
                Price = 1.50
            }
        };

        public IActionResult All()
        {
            return View(_products);
        }

        public IActionResult ById(int id)
        {
            var product = _products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult AllAsJson()
        {
            return Json(_products, new JsonSerializerOptions()
            {
                WriteIndented = true,
            });
        }

        public IActionResult AllAsTextFile()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in _products)
            {
                sb.AppendLine($"Product: {item.Id}: {item.Name} - {item.Price:f2} lv.");
            }

            Response.Headers.Add(HeaderNames.ContentDisposition, "attachment;filename=products.txt");

            return File(Encoding.UTF8.GetBytes(sb.ToString().TrimEnd()), "text/plain");
        }
    }
}
