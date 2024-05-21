using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebFood_2.Data;
using WebFood_2.Models;

namespace WebFood_2.Pages.Admin.UsersManager
{
    public class CreateModel : PageModel
    {
        private readonly WebFood_2.Data.WebFoodContext _context;

        public CreateModel(WebFood_2.Data.WebFoodContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            //return Page();
        }

        [BindProperty]
        public Users Users { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            _context.Users.Add(Users);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
