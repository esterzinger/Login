using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IOrderService
    {
        Task<Order> GetOrderById(int id);
        Task<Order> CreatOrder(Order order);
        Task UpdateOrderById(int id, Order orderToUpdate);
        Task Delete(int id);
    }
}
