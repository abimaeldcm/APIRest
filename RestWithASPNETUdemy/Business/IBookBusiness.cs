using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Business
{
    public interface IBookBusiness
    {
        Book Create(Book book);
        Book FindById(long Id);
        List<Book> FindAll();
        Book Update(Book findId, Book person);
        void Delete(long Id);

    }
}
