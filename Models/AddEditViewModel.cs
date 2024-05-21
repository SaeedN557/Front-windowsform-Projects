namespace WebFood_2.Models
{
	public class AddEditViewModel
	{
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public IFormFile Photo { get; set; }
    }
}
