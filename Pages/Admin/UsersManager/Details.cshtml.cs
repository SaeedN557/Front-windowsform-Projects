using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebFood_2.Data;
using WebFood_2.Models;

namespace WebFood_2.Pages.Admin.UsersManager
{
    public class DetailsModel : PageModel
    {
        private readonly WebFood_2.Data.WebFoodContext _context;

        public DetailsModel(WebFood_2.Data.WebFoodContext context)
        {
            _context = context;
        }

        public Users Users { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users.FirstOrDefaultAsync(m => m.UserId == id);
            if (users == null)
            {
                return NotFound();
            }
            else
            {
                Users = users;
            }
            return Page();
        }
    }
}
