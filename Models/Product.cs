using System.ComponentModel.DataAnnotations;

namespace WebFood_2.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Desc { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string ImageName { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

    }
}
