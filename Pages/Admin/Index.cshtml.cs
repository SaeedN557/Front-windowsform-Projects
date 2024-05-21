using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebFood_2.Data;
using WebFood_2.Models;

namespace WebFood_2.Pages.Admin
{
    public class IndexModel : PageModel
    {
		private WebFoodContext _context;
		public IndexModel(WebFoodContext context)
		{
			_context = context;
		}
		public IEnumerable<Product> Products { get; set; }
		//public IEnumerable<OrderDetail> OrderDetails { get; set; }


		public void OnGet()
		{
			Products = _context.Products;
			//OrderDetails = _context.OrderDetails;
		}
		public void OnPost()
		{


		}
	}
}
