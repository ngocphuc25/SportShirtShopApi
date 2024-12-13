using SWD.SportShirtShop.Repo.Entities;
using SWD.SportShirtShop.Services.Base;
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
        Task<IBusinessResult> DashBoardInfo();
        Task<IBusinessResult> UpdateConfirmStatus(int idOrder);
        Task<IBusinessResult> GetAllYourOrder(int id);
        Task<IBusinessResult> GetProcessssssssingOrdersAsync(int pageNumber, int pageSize);
        Task<IBusinessResult> UpdateStatusOrder(int orderId, string status);
    }
}
