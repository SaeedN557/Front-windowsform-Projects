using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebFood_2.Models
{
    public class RegisterViewModel
    {
        
        [MaxLength(10)]
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage ="لطفا نام کاربری خود را وارد کنید")]
        public string UserName { get; set; }
        [MaxLength(30)]
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا ایمیل خود را وارد کنید")]
        [Remote("VerifyEmail","Account")]

        public string UserEmail { get; set; }
        [MaxLength(8)]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا رمزعبور خود را وارد کنید")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,20}$", ErrorMessage = "کلمه عبور باید شامل حرف و عدد باشد")]

        public string Password { get; set; }
        [MaxLength(8)]
        [Compare("Password",ErrorMessage ="رمز عبور و تکرار آن همخوانی ندارند")]
        [DataType(DataType.Password)]
        [Display(Name = "تکرار رمز عبور")]
        [Required(ErrorMessage = "لطفا تکرار رمز عبور خود را وارد کنید")]

        public string RePassword { get; set; }
    }

    public class LoginViewModel
    {
        [MaxLength(30)]
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا نام کاربری خود را وارد کنید")]

        public string UserEmail { get; set; }
        [MaxLength(8)]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا رمزعبور خود را وارد کنید")]

        public string Password { get; set; }
        [Display(Name="مرا فراموش نکن")]
        public bool RememberMe { get; set; }
    }
}
