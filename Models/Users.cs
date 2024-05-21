using System.ComponentModel.DataAnnotations;

namespace WebFood_2.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(10)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(30)]
        public string UserEmail { get; set; }
        [Required]
        [MaxLength(8)]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public List<Order> Orders { get; set; }
    }
}
