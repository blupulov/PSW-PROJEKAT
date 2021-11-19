using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bolnica_back.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        //GET
        IEnumerable<TEntity> GetAll();
        TEntity FindById(long id);
        //POST
        void Add(TEntity entity);
        //DELETE
        void Delete(TEntity entity);

    }
}
