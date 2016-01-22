using DatabaseRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseRepository.Repository
{
    public interface IPersonRepository : IDisposable
    {

        IQueryable<Person> GetAll();

        Person GetById(int id);

        int Insert(Person pet);

        void Update(int id, Person pet);

        void Delete(int id);
    }
}
