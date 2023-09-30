using RestWithASPNETUdemy.Data;
using RestWithASPNETUdemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace RestWithASPNETUdemy.Repository.Implementations
{
    public class PersonRepostoryImplementaton : IPersonRepository
    {
        private readonly BancoContext _bancoContext;


        public PersonRepostoryImplementaton(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public Person FindById(long Id)
        {
            return _bancoContext.Person.FirstOrDefault(x => x.Id == Id);

        }

        public List<Person> FindAll()
        {
            try
            {
                var pessoas = _bancoContext.Person.ToList();
                return pessoas;
            }
            catch (Exception)
            {

                return new List<Person>();
            }

        }
        public Person Create(Person person)
        {
            _bancoContext.Person.Add(person);
            _bancoContext.SaveChanges();
            return person;
        }
        public Person Update(Person findid, Person person)
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
            if (pessoa != null)
            {
                _bancoContext.Person.Remove(pessoa);
                _bancoContext.SaveChanges();
            }
            else
            {
                throw new Exception("Usuário não encontrado");
            }

        }
        public bool Exists(long id)
        {
            return _bancoContext.Person.Any(x => x.Id == id);
        }
    }
}
