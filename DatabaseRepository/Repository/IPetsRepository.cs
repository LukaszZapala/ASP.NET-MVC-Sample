using DatabaseRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseRepository.Repository
{
    public interface IPetsRepository : IDisposable
    {
        IQueryable<Pet> GetAll();
        Pet GetById(int id);
        int Insert(Pet pet);
        void Update(int id, Pet pet);
        void Delete(int id);
    }
}
