using System;
using System.Collections.Generic;

namespace DTO
{
    public class OrderDto
    {
        public int OrderId { get; set; }

        public DateTime? OrderDate { get; set; }

        public int OrderSum { get; set; }

        public int UserId { get; set; }

        public virtual ICollection<OrderItemDto> OrderItems { get; set; } //= new List<OrderItem>();

    }

}
