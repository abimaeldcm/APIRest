using Microsoft.EntityFrameworkCore;
using RestWithASPNETUdemy.Data;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Models;
using RestWithASPNETUdemy.Repository;
using System.Collections.Generic;
using System.Linq;


// ALTERAR O TIPO DO DATA PARA ANO, POIS TÁ RUIM PARA COLOCAR O NUMERO INTEIRO.
namespace RestWithASPNETUdemy.Business.Implementations
{
    public class BookBusinessImplementaton : IBookBusiness
    {
        private readonly IBookRepository _BookRepository;

        public BookBusinessImplementaton(IBookRepository bookRepository)
        {
            _BookRepository = bookRepository;
        }
        public Book FindById(long Id)
        {
            return  _BookRepository.FindById(Id);
            
        }
        
        public List<Book> FindAll()
        {
            var book = _BookRepository.FindAll();
            return book;
        }
        public Book Create(Book book)     
        {
            _BookRepository.Create(book);
            return book;
        }
        public Book Update(Book findid, Book person)
        {
            var bookUpdate = _BookRepository.Update(findid,person);
            return (bookUpdate);
        }

        public void Delete(long Id)
        {            
            _BookRepository.Delete(Id);
        }
    }
}
