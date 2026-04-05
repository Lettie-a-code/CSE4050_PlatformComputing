using CSE4500.Models;
using CSE4500.Repositories;
namespace CSE4500.Repositories
{
    public class InMemoryDogRepository : IDogRepository
    {
        private static List<Dog> _dogs = new List<Dog>();

        public List<Dog> GetAll()
        {
            return _dogs;
        }

        public Dog GetById(int id)
        {
            return _dogs.FirstOrDefault(d => d.Id == id);
        }

        public void Add(Dog dog)
        {
            _dogs.Add(dog);
        }

        public void Update(Dog dog)
        {
            var existing = GetById(dog.Id);
            if (existing != null)
            {
                existing.Name = dog.Name;
                existing.IsCheckedIn = dog.IsCheckedIn;
            }
        }
    }
}