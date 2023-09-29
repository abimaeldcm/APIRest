using Microsoft.EntityFrameworkCore;
using RestWithASPNETUdemy.Data;
using RestWithASPNETUdemy.Models;
using System.Collections.Generic;
using System.Linq;



namespace RestWithASPNETUdemy.Services.Implementations
{
    public class PersonServceImplementaton : IPersonService
    {
        private readonly BancoContext _bancoContext;

        public PersonServceImplementaton(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public Person FindById(long Id)
        {
            return  _bancoContext.Person.FirstOrDefault(x => x.Id == Id);
            
        }
        
        public List<Person> FindAll()
        {
            var pessoas = _bancoContext.Person.ToList();
            return pessoas;
        }
        public Person Create( Person person)     
        {
            _bancoContext.Person.Add(person);
            _bancoContext.SaveChanges();
            return person;
        }
        public  Person Update(Person findid, Person person)
        {
            findid.FirstName = person.FirstName;
            findid.LastName = person.LastName;
            findid.Address = person.Address;
            findid.Gender = person.Gender;

            _bancoContext.Person.Update(findid);
            _bancoContext.SaveChanges();
            return (findid);
        }

        public void Delete(long Id)
        {            
            var pessoa = FindById(Id);
            _bancoContext.Person.Remove(pessoa);
            _bancoContext.SaveChanges();
        }
    }
}
