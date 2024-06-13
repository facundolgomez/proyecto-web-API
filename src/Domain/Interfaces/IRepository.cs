using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        void Delete(T entity);  
        List<T> GetAll();

        T? GetById(int id);
        void SaveChanges();
        void Update(T entity);  
    }
}
