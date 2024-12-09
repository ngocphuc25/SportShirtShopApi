﻿using SWD.SportShirtShop.Services.Base;
using SWD.SportShirtShop.Services.RequetsModel.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Services.Interface
{
    public interface IOrderService
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(int id);

        Task<IBusinessResult> DeleteById(int id);
        Task<IBusinessResult> CreateOrder(CreateOrderRequest createOrderRequest);
    }
}
