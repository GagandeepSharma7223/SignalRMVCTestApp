using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Service.Models;

namespace TestApplication.Service
{
    public interface IOrderService
    {
        void Delete(int id);
        List<OrderModel> GetList();
        OrderModel Save(OrderModel model);
        OrderModel Get(int Id);
    }
}
