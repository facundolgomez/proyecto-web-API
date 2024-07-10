using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : class //interfaz que debe ser implementada en el repositorio generico
    {
        T Add(T entity);
        void Delete(T entity);  
        List<T> GetAll();
        T? GetById(int id);
        void SaveChanges();
        void Update(T entity);
        
    }
}
