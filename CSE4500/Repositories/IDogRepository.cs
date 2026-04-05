using CSE4500.Models;
using System.Collections.Generic;

namespace CSE4500.Repositories
{
    public interface IDogRepository
    {
        List<Dog> GetAll();
        Dog GetById(int id);
        void Add(Dog dog);
        void Update(Dog dog);
    }
}