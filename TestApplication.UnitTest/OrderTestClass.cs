using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System.Web.Mvc;
using TestApplication.Controllers;
using TestApplication.Service;
using TestApplication.Service.Models;

namespace TestApplication.UnitTest
{
    [TestFixture]
    public class OrderTestClass
    {
        Mock<IOrderService> moq = new Mock<IOrderService>();
        [Test]
        public void TestOrdersList()
        {
            List<OrderModel> list = new List<OrderModel>();
            moq.Setup(x => x.GetList()).Returns(list);
            var controller = new OrderApiController(moq.Object);
            List<OrderModel> result = controller.GetOrders();
            Assert.That(result.Count == 0);
        }
        [Test]
        public void PostInvalidField()
        {
            var controller = new OrderApiController(moq.Object);
            controller.ModelState.AddModelError("FirstName", "Please enter First Name");
            var result = controller.ProcessOrder(new OrderModel { FirstName = String.Empty }) as OkNegotiatedContentResult<OrderModel>; ;
            Assert.That(result.Content.FirstName == string.Empty);
        }

        [Test]
        public void PostWithMissingField()
        {
            var controller = new OrderApiController(moq.Object);
            controller.ModelState.AddModelError("FirstName", "Please enter First Name");
            var result = controller.ProcessOrder(new OrderModel()) as OkNegotiatedContentResult<OrderModel>; ;
            Assert.That(result.Content.FirstName == null);
        }

        [Test]
        public void GetOrdersWithStatusOne()
        {
            List<OrderModel> list = new List<OrderModel>();
            list.Add(new OrderModel { FirstName = "Name1", Status = 1 });
            list.Add(new OrderModel { FirstName = "Name2", Status = 2 });
            list.Add(new OrderModel { FirstName = "Name3", Status = 1 });
            moq.Setup(x => x.GetList()).Returns(list);
            var controller = new OrderApiController(moq.Object);
            List<OrderModel> result = controller.GetOrdersByStatus(1);
            Assert.That(result.Count == 2);
        }

        [Test]
        public void GetOrdersWithStatusTwo()
        {
            List<OrderModel> list = new List<OrderModel>();
            list.Add(new OrderModel { FirstName = "Name1", Status = 1 });
            list.Add(new OrderModel { FirstName = "Name2", Status = 2 });
            list.Add(new OrderModel { FirstName = "Name3", Status = 1 });
            moq.Setup(x => x.GetList()).Returns(list);
            var controller = new OrderApiController(moq.Object);
            List<OrderModel> result = controller.GetOrdersByStatus(2);
            Assert.That(result.Count == 1);
        }
    }
}
