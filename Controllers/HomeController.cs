using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebFood_2.Data;
using WebFood_2.Models;
using ZarinpalSandbox;

namespace WebFood_2.Controllers;

public class HomeController : Controller
{
	private readonly ILogger<HomeController> _logger;
	private readonly WebFoodContext _webfoodcontext;

	public HomeController(ILogger<HomeController> logger, WebFoodContext webFoodContext)
	{
		_webfoodcontext = webFoodContext;
		_logger = logger;
    }

	public IActionResult Index()
	{
		var products = _webfoodcontext.Products.ToList();
		return View(products);
	}

	
	////////////////////////صفحه جزییات هر محصول ک باید ساخته شود
	public IActionResult Detail(int id)
	{
		var product = _webfoodcontext.Products.SingleOrDefault(p => p.ProductId == id);

		if (product == null)
		{
			return NotFound();
		}

		//	var categories = _webfoodcontext.Categories.ToList();

		//	var viewmodel = new DetailViewModel()
		//	{
		//		Categories = categories,
		//		Product = product
		//	};
		var model = new Product()
		{
			ProductId = product.ProductId,
			Title = product.Title,
			Desc = product.Desc,
			ImageName = product.ImageName,
			Price=product.Price
			
		};

		return View(model);
	}

	//public IActionResult AddToCart(int id)
	//{
	//	var product = _webfoodcontext.Products.Include(p => p.Item).SingleOrDefault(p => p.Id == id);
	//	if (product != null) {
	//		var cartItem = new CartItem()
	//		{
	//			Item = product.Item,
	//			Quantity = 1
	//		};
	//		_cart.addItem(cartItem);
	//	}

	//	return RedirectToAction("ShowCart");
	//}
	//public IActionResult ShowCart()
	//{
	//	var cartvm = new CartViewModel()
	//	{
	//		CartItems = _cart.CartItems,
	//		OrderTotal = _cart.CartItems.Sum(p => p.getTotalPrice())
	//	};
	//	return View(cartvm);
	//}
	public IActionResult OnlinePayment(int id)
	{
		if (HttpContext.Request.Query["Status"].ToString().ToLower() == "ok"
			&& HttpContext.Request.Query["Authority"] != "")
		{
			string authority = HttpContext.Request.Query["Authority"].ToString();
			var order = _webfoodcontext.Orders.Find(id);
			var payment = new Payment(order.Sum);
			var result = payment.Verification(authority).Result;
			if (result.Status == 100)
			{
				order.IsFinally = true;
				_webfoodcontext.Update(order);
				_webfoodcontext.SaveChanges();
				ViewBag.code = result.RefId;
				return View();
			}
			else
			{
				return NotFound();
			}
        }
		else
		{
			return NotFound();
		}
	}


	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}
