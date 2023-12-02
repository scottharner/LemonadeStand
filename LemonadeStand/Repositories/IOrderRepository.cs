using LemonadeStand.Models;

namespace LemonadeStand.Repositories
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
