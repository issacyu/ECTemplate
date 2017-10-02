using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECTemplate.Domain.Entities;

namespace ECTemplate.Domain.Abstract
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetails> OrderDetails { get; }

        void AddOrderDetail(int orderId, Cart cart);

        IEnumerable<OrderDetails> GetOrderDetails(int orderId);
    }
}
