using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        EsterChaniContext _EsterChaniContext;
        public OrderRepository(EsterChaniContext EsterTziviContext)
        {
            _EsterChaniContext = EsterTziviContext;
        }
       // public async Task<List<Order>> GetAll()
       // {
       //     return (await _EsterChaniContext.Orders.FindAsync().ToListAsync());
       // }

        // GET api/<UserController>/5

        public async Task<Order> GetOrderById(int id)
        {
            Order order = await _EsterChaniContext.Orders.FindAsync(id);

            return order; //write in c# code
            return null;


        }

        // POST api/<UserController>

        public async Task<Order> CreatOrder(Order order)
        {
            await _EsterChaniContext.Orders.AddAsync(order);
            await _EsterChaniContext.SaveChangesAsync();

            return order;

      
        }



        // PUT api/<UserController>/5

        public async Task<Order> UpdateOrderById(int id, Order orderToUpdate)
        {

            var order = await _EsterChaniContext.Orders.FindAsync(id);
            if (order == null)
            {
                return null;
            }
            _EsterChaniContext.Entry(order).CurrentValues.SetValues(orderToUpdate);
            await _EsterChaniContext.SaveChangesAsync();
            return orderToUpdate;


        }

        // DELETE api/<UserController>/
        public async Task Delete(int id)
        {
            var order = await _EsterChaniContext.Users.FindAsync(id);
            if (order != null)
            {
                _EsterChaniContext.Users.Remove(order);
                _EsterChaniContext.SaveChanges();
            }
        }
    }
}
