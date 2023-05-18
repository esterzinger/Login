using Entity;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderService :IOrderService
    {
        IOrderRepository _OrderRepository;
        IProductRepository _ProductRepository;
        

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _OrderRepository = orderRepository;
            _ProductRepository= productRepository;
        }

       // public async Task<List<Order>> GetAllOrders()
        //{
       //     return (await _OrderRepository.GetAll());

      //  }

        // GET api/<UserController>/5

        public async Task<Order> GetOrderById(int id)
        {
            return await _OrderRepository.GetOrderById(id);


        }

        // POST api/<UserController>

        public async Task<Order> CreatOrder(Order order)
        {
            int sum = 0;
            foreach (var i in order.OrderItems)
            {
                Product product = await _ProductRepository.GetProductById(i.ProductId);
                sum += product.Price * i.Quantity;;
              
            }
            if (sum != order.OrderSum)
                order.OrderSum = sum;

            return await _OrderRepository.CreatOrder(order);


        }




        // PUT api/<UserController>/5

        public async Task UpdateOrderById(int id, Order orderToUpdate)
        {
            await _OrderRepository.UpdateOrderById(id, orderToUpdate);


        }

        // DELETE api/<UserController>/
        public async Task Delete(int id)
        {
            await _OrderRepository.Delete(id);
        }
    }
}
