using RestWithASPNETUdemy.Models;
using RestWithASPNETUdemy.Models.Base;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindById(long Id);
        List<T> FindAll();
        T Update(T findId, T item);
        void Delete(long Id);
        bool Exists(long id);
    }
}
