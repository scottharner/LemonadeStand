using LemonadeStand.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LemonadeStand.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly LemonadeStandDbContext _lemonadeStandDbContext;
        public string? ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default;

        private ShoppingCart(LemonadeStandDbContext lemonadeStandDbContext)
        {
            _lemonadeStandDbContext = lemonadeStandDbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;
            LemonadeStandDbContext context = services.GetService<LemonadeStandDbContext>() ?? throw new Exception("Error initializing");

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

            session?.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Beverage beverage)
        {
            var shoppingCartItem = _lemonadeStandDbContext.ShoppingCartItems.SingleOrDefault(s => s.Beverage.BeverageId == beverage.BeverageId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Beverage = beverage,
                    Amount = 1
                };

                _lemonadeStandDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }

            _lemonadeStandDbContext.SaveChanges();
        }

        public void ClearCart()
        {
            var cartItems = _lemonadeStandDbContext.ShoppingCartItems.Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _lemonadeStandDbContext.ShoppingCartItems.RemoveRange(cartItems);

            _lemonadeStandDbContext.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??= _lemonadeStandDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId).Include(s => s.Beverage).ToList();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _lemonadeStandDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId).Select(c => c.Beverage.Price * c.Amount).Sum();

            return total;
        }

        public int RemoveFromCart(Beverage beverage)
        {
            var shoppingCartItem = _lemonadeStandDbContext.ShoppingCartItems.SingleOrDefault(s => s.Beverage.BeverageId == beverage.BeverageId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;
            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _lemonadeStandDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _lemonadeStandDbContext.SaveChanges(true);

            return localAmount;
        }
    }
}
