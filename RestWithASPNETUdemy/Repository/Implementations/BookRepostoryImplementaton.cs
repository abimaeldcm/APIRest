using RestWithASPNETUdemy.Data;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace RestWithASPNETUdemy.Repository.Implementations
{
    public class BookRepostoryImplementaton : IBookRepository
    {
        private readonly BancoContext _bancoContext;


        public BookRepostoryImplementaton(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public Book FindById(long Id)
        {
            return _bancoContext.Books.FirstOrDefault(x => x.Id == Id);

        }

        public List<Book> FindAll()
        {
            try
            {
                var books = _bancoContext.Books.ToList();
                return books;
            }
            catch (Exception)
            {

                return new List<Book>();
            }

        }
        public Book Create(Book book)
        {
            _bancoContext.Books.Add(book);
            _bancoContext.SaveChanges();
            return book;
        }
        public Book Update(Book findid, Book book)
        {
            findid.Author = book.Author;
            findid.Title = book.Title;
            findid.Price = book.Price;
            findid.LaunchDate = book.LaunchDate;

            _bancoContext.Books.Update(findid);
            _bancoContext.SaveChanges();
            return (findid);
        }

        public void Delete(long Id)
        {
            var book = FindById(Id);
            if (book != null)
            {
                _bancoContext.Books.Remove(book);
                _bancoContext.SaveChanges();
            }
            else
            {
                throw new Exception("Livro não encontrado");
            }

        }
        public bool Exists(long id)
        {
            return _bancoContext.Person.Any(x => x.Id == id);
        }
    }
}
