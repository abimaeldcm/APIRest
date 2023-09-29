using RestWithASPNETUdemy.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindById(long Id);
        List<Person> FindAll();
        Person Update(Person findId, Person person);
        void Delete(long Id);

    }
}
