namespace LemonadeStand.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int BeverageId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public Beverage Beverage { get; set; } = default!;
        public Order Order { get; set; } = default!;
    }
}
