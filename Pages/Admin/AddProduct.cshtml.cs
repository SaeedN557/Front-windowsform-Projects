using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using WebFood_2.Data;
using WebFood_2.Models;

namespace WebFood_2.Pages.Admin
{
    public class AddProductModel : PageModel
    {
        private WebFoodContext _context;
        public AddProductModel(WebFoodContext context)
        {
            _context=context;
        }
        [BindProperty]
        public AddEditViewModel AddEditViewModel { get; set; }
        public void OnGet()
        {

        }
        public IActionResult OnPost() 
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            
            var product = new Product()
            {
                Price=AddEditViewModel.Price,
                Title = AddEditViewModel.Title,
                Desc=AddEditViewModel.Desc,
                Count=AddEditViewModel.Count,
                ImageName="no name"
            };
            _context.Add(product);
            _context.SaveChanges();
            

            if (AddEditViewModel.Photo?.Length > 0)
            {
                string filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images",product.ProductId+Path.GetExtension(AddEditViewModel.Photo.FileName));
            using(var stream=new FileStream(filepath, FileMode.Create))
                {
                    AddEditViewModel.Photo.CopyTo(stream);
                }
                int id = product.ProductId;
                string PhotoPath = filepath.Split('.').Last();
                product.ImageName = Convert.ToString(id)+'.'+PhotoPath;
				_context.SaveChanges();
			}
			
			
			return RedirectToPage("");
        }
    }
}
