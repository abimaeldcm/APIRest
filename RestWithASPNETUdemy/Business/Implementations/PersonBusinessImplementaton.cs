using Microsoft.EntityFrameworkCore;
using RestWithASPNETUdemy.Data;
using RestWithASPNETUdemy.Models;
using RestWithASPNETUdemy.Repository;
using System.Collections.Generic;
using System.Linq;



namespace RestWithASPNETUdemy.Business.Implementations
{
    public class PersonBusinessImplementaton : IPersonBusiness
    {
        private readonly IPersonRepository _PersonRepository;

        public PersonBusinessImplementaton(IPersonRepository personRepository)
        {
            _PersonRepository = personRepository;
        }
        public Person FindById(long Id)
        {
            return  _PersonRepository.FindById(Id);
            
        }
        
        public List<Person> FindAll()
        {
            var pessoas = _PersonRepository.FindAll();
            return pessoas;
        }
        public Person Create( Person person)     
        {
            _PersonRepository.Create(person);
            return person;
        }
        public  Person Update(Person findid, Person person)
        {
            var personUpdate = _PersonRepository.Update(findid,person);
            return (personUpdate);
        }

        public void Delete(long Id)
        {            
            _PersonRepository.Delete(Id);
        }
    }
}
