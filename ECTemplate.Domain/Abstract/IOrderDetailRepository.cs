using System;
using System.Collections.Generic;
using ECTemplate.Domain.Entities;

namespace ECTemplate.Domain.Abstract
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetails> OrderDetails { get; }

        void AddOrderDetail(Orders order, Cart cart);

        IEnumerable<OrderDetails> GetOrderDetails(Guid orderId);
    }
}
