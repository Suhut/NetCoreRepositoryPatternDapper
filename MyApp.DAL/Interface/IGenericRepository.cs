using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DAL.Interface
{
    public interface IGenericRepository<T, TId> where T : class
    {
        T GetById(TId id); 
        TId Add(T entity);
        TId Update(T entity);
    }
}
