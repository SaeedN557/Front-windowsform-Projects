using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebFood_2.Data.Repositories;
using WebFood_2.Models;

namespace WebFood_2.Controllers
{
    public class AccountController : Controller
    {
        private IUserRepository _userRepository;
        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        #region register
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            
            //if (model.Password != model.RePassword)
            //{
            //    ModelState.AddModelError("UserEmail", "رمز عبور با تکرار آن همخوانی ندارد");

            //}

            Users user = new Users()
            {
                UserName = model.UserName,
                UserEmail=model.UserEmail,
                Password=model.Password,
                IsAdmin=false
            };
            if (user.UserName == null)
            {

            }
            _userRepository.AddUser(user);
            return View("SuccessRegister",model);
        }
        public IActionResult VerifyEmail(string email)
        {
            if (_userRepository.IsEmailExist(email.ToLower()))
            {
                return Json("ایمیل وارد شده از قبل در سیستم وجود دارد");
            }
            return Json(true);
        }
        #endregion
        #region login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = _userRepository.GetUsersLogin(model.UserEmail.ToLower() , model.Password);
            if (user == null)
            {
                ModelState.AddModelError("UserEmail", "اطلاعات وارد شده نادرست");
                return View(model);
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                new Claim(ClaimTypes.Email,user.UserEmail),
                new Claim("IsAdmin",user.IsAdmin.ToString())
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal=new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties
            {
                IsPersistent = model.RememberMe
            };
            HttpContext.SignInAsync(principal, properties);

            return Redirect("/");
        }
        
        #endregion
        #region logout
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Account/Login");
        }
        #endregion

        







    }
}
