using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Data.Entities;

namespace TestApplication.Data
{
    public interface IUnitOfWork
    {
        GenericRepository<DevTest> Developers { get; }
        int Save();
    }
}
