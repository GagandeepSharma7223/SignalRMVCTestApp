using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Service.Models;

namespace TestApplication.Service
{
    public interface IDevService
    {
        void Delete(int id);
        List<TestAppModel> GetList();
        TestAppModel Save(TestAppModel model);
        TestAppModel Get(int Id);
        IEnumerable<TestAppModel> GetData();
    }
}
