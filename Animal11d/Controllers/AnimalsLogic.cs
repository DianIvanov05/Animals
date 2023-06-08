using Animal11d.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal11d.Controllers
{
    public class AnimalsLogic
    {
        private AnimalsContext _animalsDbContext = new AnimalsContext();//Database
        public List<Animal> GetAll()
        {
            using (_animalsDbContext = new AnimalsContext())
            {
                List<Animal> listAnimals = _animalsDbContext.Animals.ToList();
                return listAnimals;
            }
        }

        public Animal Get(int id)
        {
            using (_animalsDbContext = new AnimalsContext())
            {
                Animal findedAnimal = _animalsDbContext.Animals.Find(id);
                if (findedAnimal != null)
                {
                    _animalsDbContext.Entry(findedAnimal).Reference(x => x.Breeds).Load();
                }
                return findedAnimal;
            }  

        }

        public void Create(Animal animal)
        {
            using (_animalsDbContext = new AnimalsContext())
            {
                _animalsDbContext.Animals.Add(animal);
                _animalsDbContext.SaveChanges();
            }
        }

        public void Update(int id, Animal animal)
        {
            using (_animalsDbContext = new AnimalsContext())
            {
                Animal findedAnimal = _animalsDbContext.Animals.Find(id);
                if (findedAnimal == null) //
                {
                    return;
                }
                findedAnimal.Age = animal.Age;
                findedAnimal.Name = animal.Name;
                findedAnimal.BreedsId = animal.BreedsId;
                _animalsDbContext.SaveChanges();
            }

        }

        public void Delete(int id)
        {
            using (_animalsDbContext = new AnimalsContext())
            {
                Animal findedAnimal = _animalsDbContext.Animals.Find(id);
                _animalsDbContext.Animals.Remove(findedAnimal);
                _animalsDbContext.SaveChanges();
            }

        }


    }
}
