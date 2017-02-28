using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestApplication.Data.Entities;
using TestApplication.Data.Context;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using TestApplication.Service.Models;
using TestApplication.Service;
using System.Text;
using System.Web.Script.Serialization;

namespace TestApplication.Controllers
{
    public class OrderController : Controller
    {
        private string url = "http://localhost:4304/api/OrderApi";
        private HttpClient client;
        public OrderController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: /Order/
        public async Task<ActionResult> Index()
        {
            var orders = new List<OrderModel>();
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                orders = JsonConvert.DeserializeObject<List<OrderModel>>(responseData);
                return View(orders);
            }
            return View(orders);
        }

        // GET: /Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(OrderModel order)
        {
            order.Status = 1;
            if (ModelState.IsValid)
            {
                url = Path.Combine(url, "ProcessOrder");
                var now = DateTime.Now;
                if (order.CardExpirationMonth < now.Month && order.CardExpirationYear < now.Year)
                    order.Status = 2;
                JavaScriptSerializer js = new JavaScriptSerializer();
                string jsonData = js.Serialize(order);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = await client.PostAsync(url, new StringContent(jsonData, Encoding.UTF8, "application/json"));
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(order);
        }

        // GET: /Order/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderModel order = new OrderModel();
            var uriBuilder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query.Add("id", id.ToString());
            uriBuilder.Query = query.ToString();
            HttpResponseMessage responseMessage = await client.GetAsync(uriBuilder.Uri);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                order = JsonConvert.DeserializeObject<OrderModel>(responseData);
            }
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: /Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var uriBuilder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query.Add("id", id.ToString());
            uriBuilder.Query = query.ToString();
            HttpResponseMessage responseMessage = await client.DeleteAsync(uriBuilder.Uri);
            return RedirectToAction("Index");
        }

    }
}
