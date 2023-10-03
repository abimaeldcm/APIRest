using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Repository
{
    public interface IBookRepository
    {
        Book Create(Book person);
        Book FindById(long Id);
        List<Book> FindAll();
        Book Update(Book findId, Book book);
        void Delete(long Id);
        bool Exists(long id);
    }
}
