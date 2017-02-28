using AutoMapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Data;
using System.Data.Entity.Infrastructure;
using TestApplication.Service.Hubs;
using TestApplication.Data.Entities;
using TestApplication.Data.Context;
using TestApplication.Service.Models;

namespace TestApplication.Service
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork UnitOfWork;
        public OrderService(IUnitOfWork _UnitOfWork)
        {
            UnitOfWork = _UnitOfWork;
        }
        public void Delete(int id)
        {
            UnitOfWork.Orders.Delete(id);
            UnitOfWork.Save();
        }
        public List<OrderModel> GetList()
        {
            var list = UnitOfWork.Orders.Get();
            return Mapper.Map<List<OrderModel>>(list);
        }
        public OrderModel Save(OrderModel model)
        {
            var entity = Mapper.Map<Order>(model);
            if (entity.ID == 0)
            {
                UnitOfWork.Orders.Insert(entity);
                UnitOfWork.Save();
            }
            else
            {
                UnitOfWork.Orders.Update(entity);
                UnitOfWork.Save();
            }
            entity = UnitOfWork.Orders.GetByID(entity.ID);
            return Mapper.Map<OrderModel>(entity);
        }
        public OrderModel Get(int Id)
        {
            return Mapper.Map<OrderModel>(UnitOfWork.Orders.GetByID(Id));
        }
        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            JobHub.Show();
        }
    }
}
