using DatabaseRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseRepository.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private PetContext petContex;

        public PersonRepository()
        {
            this.petContex = new PetContext();
        }

        public IQueryable<Person> GetAll()
        {
            return petContex.Persons;
        }

        public Person GetById(int id)
        {
            return this.petContex.Persons.SingleOrDefault(x => x.Id == id);
        }

        public int Insert(Person Person)
        {
            this.petContex.Persons.Add(Person);
            this.petContex.SaveChanges();

            return Person.Id;
        }

        public void Update(int id, Person Person)
        {
            Person dbPerson = GetById(id);
            dbPerson.FirstName = Person.FirstName;
            dbPerson.LastName = Person.LastName;
            dbPerson.Age = Person.Age;
            dbPerson.Pets = Person.Pets;

            this.petContex.SaveChanges();
        }

        public void Delete(int id)
        {
            Person dbPerson = this.GetById(id);

            if (dbPerson != null)
            {
                this.petContex.Persons.Remove(dbPerson);
            }
        }

        public void Dispose()
        {
            this.petContex.Dispose();
        }
    }
}
