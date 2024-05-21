namespace WebFood_2.Models
{
    public class Cart
    {
        public int OrderDetailId { get; set; }
        public string ImageName { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public int Sum { get; set; }
    }
}
