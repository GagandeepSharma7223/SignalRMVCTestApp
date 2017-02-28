using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TestApplication.Data.Entities;
using TestApplication.Data.Context;
using TestApplication.Service;
using TestApplication.Service.Models;

namespace TestApplication.Controllers
{
    public class OrderApiController : ApiController
    {
        private IOrderService service;
        public OrderApiController(IOrderService _service)
        {
            service = _service;
        }
        // GET api/OrderApi
        public List<OrderModel> GetOrders()
        {
            return service.GetList();
        }

        public List<OrderModel> GetOrdersByStatus(int status)
        {
            return service.GetList().Where(x => x.Status == status).ToList();
        }

        // GET api/OrderApi/5
        public IHttpActionResult GetOrder(int id)
        {
            var order = service.Get(id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // PUT api/OrderApi/5
        public IHttpActionResult PutOrder(int id, OrderModel order)
        {
            if (id != order.ID)
            {
                return BadRequest();
            }

            try
            {
                service.Save(order);
            }
            catch (DbUpdateConcurrencyException)
            {
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/OrderApi
        public IHttpActionResult ProcessOrder([FromBody]OrderModel order)
        {
            if (ModelState.IsValid)
            {
                service.Save(order);
                return Ok();
            }
            return Ok(order);
            //return CreatedAtRoute("DefaultApi", new { id = order.ID }, order);
        }

        // DELETE api/OrderApi/5
        public IHttpActionResult DeleteOrder(int id)
        {
            var order = service.Get(id);
            if (order == null)
            {
                return NotFound();
            }
            service.Delete(id);
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }

        private bool OrderExists(int id)
        {
            return service.GetList().Count(e => e.ID == id) > 0;
        }
    }
}