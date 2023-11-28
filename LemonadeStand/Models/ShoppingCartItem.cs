namespace LemonadeStand.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Beverage Beverage { get; set; }
        public int Amount { get; set; }
        public string? ShoppingCartId { get; set; }
    }
}
