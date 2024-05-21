using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebFood_2.Data;
using WebFood_2.Models;

namespace WebFood_2.Pages.Admin
{
    public class DeleteProductModel : PageModel
    {
		private WebFoodContext _context;
		public DeleteProductModel(WebFoodContext context)
		{
			_context = context;
		}
		[BindProperty]
		public Product Product { get; set; }

		public void OnGet(int id)
		{
			Product = _context.Products.SingleOrDefault(p=>p.ProductId==id);
		}
		public IActionResult OnPost()
		{
			var product = _context.Products.Find(Product.ProductId);
			_context.Products.Remove(product);

			_context.SaveChanges();

			string filePath = Path.Combine(Directory.GetCurrentDirectory(),
				"wwwroot",
				"images",
				product.ProductId + ".jpg");
			if (System.IO.File.Exists(filePath))
			{
				System.IO.File.Delete(filePath);
			}

			return RedirectToPage("Index");
		}
	}
}
