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
    public class DevService : IDevService
    {
        private readonly IUnitOfWork UnitOfWork;
        public DevService(IUnitOfWork _UnitOfWork)
        {
            UnitOfWork = _UnitOfWork;
        }
        public void Delete(int id)
        {
            UnitOfWork.Developers.Delete(id);
            UnitOfWork.Save();
        }
        public List<TestAppModel> GetList()
        {
            var list = UnitOfWork.Developers.Get();
            return Mapper.Map<List<TestAppModel>>(list);
        }
        public TestAppModel Save(TestAppModel model)
        {
            model.Date = DateTime.Now;
            var entity = Mapper.Map<DevTest>(model);
            if (entity.ID == 0)
            {
                UnitOfWork.Developers.Insert(entity);
                UnitOfWork.Save();
            }
            else
            {
                UnitOfWork.Developers.Update(entity);
                UnitOfWork.Save();
            }
            entity = UnitOfWork.Developers.GetByID(entity.ID);
            return Mapper.Map<TestAppModel>(entity);
        }
        public TestAppModel Get(int Id)
        {
            return Mapper.Map<TestAppModel>(UnitOfWork.Developers.GetByID(Id));
        }

        public IEnumerable<TestAppModel> GetData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            string commandText = null;

            using (var db = new TestDBContext())
            {
                var query = db.DevTests as DbQuery<DevTest>;

                commandText = query.ToString();
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    connection.Open();

                    var sqlDependency = new SqlDependency(command);

                    sqlDependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                    // NOTE: You have to execute the command, or the notification will never fire.
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return reader.Cast<IDataRecord>()
                            .Select(x => new TestAppModel()
                            {
                                AffiliateName = x["AffiliateName"] != DBNull.Value ? x["AffiliateName"].ToString() : String.Empty,
                                CampaignName = x["CampaignName"] != DBNull.Value ? x["CampaignName"].ToString() : String.Empty,
                                ID = (int)x["ID"],
                                Date = x["Date"] != DBNull.Value ? (DateTime)x["Date"] : DateTime.Now,
                                Clicks = x["Clicks"] != DBNull.Value ? (int)x["Clicks"] : 0,
                                Conversions = x["Conversions"] != DBNull.Value ? (int)x["Conversions"] : 0,
                                Impressions = x["Impressions"] != DBNull.Value ? (int)x["Impressions"] : 0,
                            }).ToList();
                    }
                }
            }
        }
        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            JobHub.Show();
        }
    }
}
