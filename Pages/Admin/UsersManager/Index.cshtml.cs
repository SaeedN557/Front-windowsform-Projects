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
    public class IndexModel : PageModel
    {
        private readonly WebFood_2.Data.WebFoodContext _context;

        public IndexModel(WebFood_2.Data.WebFoodContext context)
        {
            _context = context;
        }

        public IList<Users> Users { get;set; } = default!;

        public async Task OnGetAsync()
        {
			
			Users = await _context.Users.ToListAsync();
        }
    }
}
