using Entity;

namespace Repositories
{
    public interface IOrderRepository
    {
        Task<Order> CreatOrder(Order order);
        Task Delete(int id);
        //Task<List<Order>> GetAll();
        Task<Order> GetOrderById(int id);
        Task<Order> UpdateOrderById(int id, Order orderToUpdate);
    }
}