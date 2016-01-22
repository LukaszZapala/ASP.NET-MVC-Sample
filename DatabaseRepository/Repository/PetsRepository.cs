using DatabaseRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseRepository.Repository
{
    public class PetsRepository : IPetsRepository
    {
        private PetContext petContext;

        public PetsRepository()
        {
            petContext = new PetContext();
        }

        public void Delete(int id)
        {
            var pet = petContext.Pets.SingleOrDefault(x => x.Id == id);

            if (pet != null)
            {
                petContext.Pets.Remove(pet);
            }
        }

        public void Dispose()
        {
            petContext.Dispose();
        }

        public IQueryable<Pet> GetAll()
        {
            return petContext.Pets;
        }

        public Pet GetById(int id)
        {
            return petContext.Pets.SingleOrDefault(x => x.Id == id);
        }

        public int Insert(Pet pet)
        {
            petContext.Pets.Add(pet);
            petContext.SaveChanges();

            return pet.Id;
        }

        public void Update(int id, Pet pet)
        {
            var dbPet = petContext.Pets.SingleOrDefault(x => x.Id == id);
            dbPet.Name = pet.Name;

            petContext.SaveChanges();
        }
    }
}
