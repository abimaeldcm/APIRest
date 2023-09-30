using RestWithASPNETUdemy.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Repository
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person FindById(long Id);
        List<Person> FindAll();
        Person Update(Person findId, Person person);
        void Delete(long Id);
        bool Exists(long id);
    }
}
