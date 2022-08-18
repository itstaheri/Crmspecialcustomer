using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frameworkes
{
    public interface IGenericRepository<in T,Value>
    {
        Task Create(T entity);
        Task SaveChanges();
        Task<Value> GetBy(long Id);
        Task<List<Value>> GetAll();
    }
}
