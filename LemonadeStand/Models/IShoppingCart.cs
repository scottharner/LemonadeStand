namespace LemonadeStand.Models
{
    public interface IShoppingCart
    {
        void AddToCart(Beverage beverage);
        int RemoveFromCart(Beverage beverage);
        List<ShoppingCartItem> GetShoppingCartItems();
        void ClearCart();
        decimal GetShoppingCartTotal();
        List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
