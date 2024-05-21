using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata.Ecma335;
using WebFood_2.Data;
using WebFood_2.Models;

namespace WebFood_2.Pages.Admin
{
    public class EditProductModel : PageModel
    {
        private WebFoodContext _context;
        public EditProductModel(WebFoodContext context)
        {
            _context = context;
        }
        [BindProperty]
        public AddEditViewModel AddEditViewModel { get; set; }

        public void OnGet(int id)
        {
            AddEditViewModel = _context.Products.Where(x => x.ProductId == id).Select(s => new AddEditViewModel()
            {
                ProductId = s.ProductId,
                Title = s.Title,
                Desc = s.Desc,
                Price = s.Price,
                Count = s.Count
            }).FirstOrDefault();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var product = _context.Products.Find(AddEditViewModel.ProductId);
            product.Title = AddEditViewModel.Title;
            product.Desc = AddEditViewModel.Desc;
            product.Price = AddEditViewModel.Price;
            product.Count = AddEditViewModel.Count;
            _context.SaveChanges();
            if (AddEditViewModel.Photo?.Length > 0)
            {
                string filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", product.ProductId + Path.GetExtension(AddEditViewModel.Photo.FileName));
                using (var stream = new FileStream(filepath, FileMode.Create))
                {
                    AddEditViewModel.Photo.CopyTo(stream);
                }
                product.ImageName = filepath;
                _context.SaveChanges();
            }


            return RedirectToPage("Index");
        }
    }
}
