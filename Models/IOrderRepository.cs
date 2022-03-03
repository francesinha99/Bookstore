﻿using System;
using System.Linq;

namespace Bookstore.Models
{
    public interface IOrderRepository
    {
        IQueryable<Order> Order { get; }

        void SaveOrder(Order order);
    }
}
