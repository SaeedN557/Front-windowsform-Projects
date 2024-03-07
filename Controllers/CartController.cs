using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebFood_2.Data;
using WebFood_2.Data.Repositories;
using WebFood_2.Models;
using ZarinpalSandbox;

namespace WebFood_2.Controllers
{
	public class CartController : Controller
	{
        private WebFoodContext _ctx;

        public CartController(WebFoodContext ctx)
        {
            _ctx = ctx;
        }
        [Authorize]
        public IActionResult AddToCart(int id)
        {
            string CurrentUserID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Order order = _ctx.Orders.SingleOrDefault(o => o.UserId == int.Parse(CurrentUserID) && !o.IsFinally);
            if (order == null)
            {
                order = new Order()
                {
                    UserId = int.Parse(CurrentUserID),
                    CreationDate = DateTime.Now,
                    IsFinally = false,
                    Sum = 0
                    
                };
                _ctx.Orders.Add(order);
                //Order order_2 = _ctx.Orders.SingleOrDefault(o => o.UserId == int.Parse(CurrentUserID) && !o.IsFinally);
				_ctx.OrderDetails.Add(new OrderDetail()
				{
					OrderId = order.OrderId,
					Count = 1,
					Price = _ctx.Products.Find(id).Price,
					ProductId = id
				});
                _ctx.SaveChanges();
			}
            else
            {
                var details = _ctx.OrderDetails.SingleOrDefault(d => d.OrderId == order.OrderId && d.ProductId == id);
                if (details == null)
                {
                    _ctx.OrderDetails.Add(new OrderDetail()
                    {
                        OrderId = order.OrderId,
                        Count = 1,
                        Price = _ctx.Products.Find(id).Price,
                        ProductId = id
                    });
                }
                else
                {
                    details.Count += 1;
                    _ctx.Update(details);
                }

                _ctx.SaveChanges();
            }
            UpdateSumOrder(order.OrderId);
            return Redirect("/Cart/ShowCart");
        }

        public void UpdateSumOrder(int orderId)
        {
            var order = _ctx.Orders.Find(orderId);
            order.Sum = _ctx.OrderDetails.Where(o => o.OrderId == order.OrderId).Select(d => d.Count * d.Price).Sum();
            _ctx.Update(order);
            _ctx.SaveChanges();
        }
        [Authorize]
        public IActionResult ShowCart()
        {
			#region
			List<Cart> _cart=new List<Cart>();
            string CurrentUserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //if (CurrentUserId != null)    authoriza darim bejash!
            Order order = _ctx.Orders.SingleOrDefault(o => o.UserId == int.Parse(CurrentUserId) && !o.IsFinally);
            if (order != null)
            {
                var details = _ctx.OrderDetails.Where(d => d.OrderId == order.OrderId).ToList();
                foreach (var x in details)
                {
                    var product = _ctx.Products.Find(x.ProductId);
                    _cart.Add(new Cart()
                    {
                        OrderDetailId=x.OrderDetailID,
                        Price=x.Price,
                        Count = x.Count,
                        Name = product.Title,
                        ImageName = product.ImageName,
                        Sum=x.Count*x.Price
                    });

                }
			}
			#endregion
			int CurrentUserID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var order_show = _ctx.Orders.Where(x => x.UserId == CurrentUserID&&!x.IsFinally).Include(x => x.OrderDetails).ThenInclude(p => p.Product).FirstOrDefault();
			return View("Cart",order_show);
        }
        public IActionResult DeleteFromCart(int id)
        {
            var orderDetail = _ctx.OrderDetails.Find(id);
            _ctx.Remove(orderDetail);
            _ctx.SaveChanges();

            return RedirectToAction("ShowCart");
        }


			public IActionResult Command(int id)
			{
				var orderDetail = _ctx.OrderDetails.Find(id);

							orderDetail.Count += 1;
							_ctx.Update(orderDetail);
							
			#region decrease
			//case "down":
			//	{
			//		orderDetail.Count -= 1;
			//		if (orderDetail.Count == 0)
			//		{
			//			_ctx.OrderDetails.Remove(orderDetail);
			//		}
			//		else
			//		{
			//			_ctx.Update(orderDetail);
			//		}

			//		break;
			//	}
			//}
			#endregion
			_ctx.SaveChanges();
			return RedirectToAction("ShowCart");
		}
        public IActionResult Payment(int id)
        {
            var user = _ctx.Users.FirstOrDefault(x => x.UserId == id);
            var order = _ctx.Orders.FirstOrDefault(o => !o.IsFinally);
            if (order == null)
            {
                return NotFound();
            }
            var payment = new Payment(order.Sum);
            var result = payment.PaymentRequest($"پرداخت فاکتور {order.OrderId}", "https://localhost:7036/Home/OnlinePayment" + order.OrderId, user.UserEmail, user.UserName);

            if (result.Result.Status == 100)
            {
                return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + result.Result.Authority);
            }
            else
            {
                return BadRequest();
            }
        }


    }
	
}
