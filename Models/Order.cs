using WebFood_2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebFood_2.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]

        public DateTime CreationDate { get; set; }
        [Required]
        public int Sum { get; set; }
        [Required]

        public bool IsFinally { get; set; }
        [ForeignKey("UserId")]
        public Users Users { get; set; }
    
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
