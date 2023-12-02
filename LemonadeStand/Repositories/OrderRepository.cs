using LemonadeStand.Models;

namespace LemonadeStand.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly LemonadeStandDbContext _lemonadeStandDbContext;
        private readonly IShoppingCart _shoppingCart;

        public OrderRepository(LemonadeStandDbContext lemonadeStandDbContext, IShoppingCart shoppingCart)
        {
            _lemonadeStandDbContext = lemonadeStandDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();

            //adding the order with its details

            foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    BeverageId = shoppingCartItem.Beverage.BeverageId,
                    Price = shoppingCartItem.Beverage.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            _lemonadeStandDbContext.Orders.Add(order);

            _lemonadeStandDbContext.SaveChanges();
        }
    }
}
