using System.Xml.Linq;
using EksamenREST.Model;

namespace EksamenREST.Repository
{
    public class RabbitsRepository
    {
        private int nextId = 1;
        private readonly List<Rabbit> rabbits = new();

        public RabbitsRepository(bool includeData = true)
        {
            if (includeData)
            {
                Add(new Rabbit { Name = "Ninus", Color = "Hvid", Weight = 5, MotherId = null });
                Add(new Rabbit { Name = "Karl", Color = "Rødbrun", Weight = 4.5, MotherId = 1 });
                Add(new Rabbit { Name = "Misse", Color = "Hvid", Weight = 4.6, MotherId = 1 });
                Add(new Rabbit { Name = "Plet", Color = "Brun", Weight = 5.6, MotherId = 2 });
            }
        }


        public IEnumerable<Rabbit> GetAll()
        {
            return new List<Rabbit>(rabbits);
        }

        public Rabbit? GetById(int id)
        {
            return rabbits.FirstOrDefault(c => c.Id == id);
        }


        public Rabbit Add(Rabbit rabbit)
        {
            rabbit.Id = nextId++;
            rabbits.Add(rabbit);
            return rabbit;
        }


        public Rabbit? Delete(int id)
        {
            Rabbit? rabbit = GetById(id);
            if (rabbit == null)
            {
                return null;
            }
            rabbits.Remove(rabbit);
            return rabbit;  
        }



    }
}
