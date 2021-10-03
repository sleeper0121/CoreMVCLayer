using System;
using System.Collections.Generic;

namespace Service.EF
{
    public interface IBaseService<TEntity>
    {
        List<TEntity> GetAll();

        TEntity FindById(int id);

        bool Create(TEntity tDto);

        bool Delete(int id);

        bool Update(TEntity entity);
    }
}
