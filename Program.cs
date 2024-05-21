using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebFood_2.Data;
using WebFood_2.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<WebFoodContext>(options => options.UseSqlServer(
"Data Source=.;Initial Catalog=WebFood_DB;Integrated Security=true;encrypt = false"
));
/*trusted_connection = true; encrypt = false*/

builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
{
    option.LoginPath = "/Account/Login";
    option.LogoutPath= "/Acount/Logout";
    option.ExpireTimeSpan = TimeSpan.FromDays(1);
});
builder.Services.AddRazorPages();
var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
    
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseAuthentication();
app.UseAuthorization();
//app.Use(async (context, next) =>
//{
//    if (context.Request.Path.StartsWithSegments("/Admin"))
//    {
//        if (!context.User.Identity.IsAuthenticated)
//        {
//            context.Response.Redirect("/Account/Login");
//        }
//        else if (!bool.Parse(context.User.FindFirstValue("IsAdmin")))
//        {
//            context.Response.Redirect("/Account/Login");
//        }
//        await next.Invoke();
//    }
//});
app.Run();
