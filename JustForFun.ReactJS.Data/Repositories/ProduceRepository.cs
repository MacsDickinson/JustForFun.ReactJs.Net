using System.Collections.Generic;

namespace JustForFun.ReactJS.Data.Domain
{
    public class ProduceRepository
    {
        private IDictionary<string, Produce> _produce;

        public ProduceRepository()
        {
            _produce = new Dictionary<string, Produce>();
        }

        public void SetupSampleData()
        {
            Add(new Produce { Name = "Ginger", Cost = 1.0m, Measurement = "Inches" });
            Add(new Produce { Name = "Pineapple", Cost = 1.0m, Measurement = "Whole" });
            Add(new Produce { Name = "Pear", Cost = 1.0m, Measurement = "Whole" });
            Add(new Produce { Name = "Lemon", Cost = 1.0m, Measurement = "Whole" });
            Add(new Produce { Name = "Orange", Cost = 1.0m, Measurement = "Whole" });
            Add(new Produce { Name = "Celery", Cost = 1.0m, Measurement = "Stalks" });
            Add(new Produce { Name = "Spinach", Cost = 1.0m, Measurement = "Leaves" });
            Add(new Produce { Name = "Cabbage", Cost = 1.0m, Measurement = "Whole" });
            Add(new Produce { Name = "Lettuce", Cost = 1.0m, Measurement = "Leaves" });
            Add(new Produce { Name = "Grapefruit", Cost = 1.0m, Measurement = "Leaves" });
            Add(new Produce { Name = "Broccoli", Cost = 1.0m, Measurement = "Whole", Substitutions = new List<Produce> { Get("Spinach"), Get("Cabbage"), Get("Lettuce") } });
            Add(new Produce { Name = "Kale", Cost = 1.0m, Measurement = "Leaves", Substitutions = new List<Produce> { Get("Spinach"), Get("Lettuce") } });
            Add(new Produce { Name = "Basil", Cost = 1.0m, Measurement = "Handfull" });
            Add(new Produce { Name = "Mint", Cost = 1.0m, Measurement = "Handfull", Substitutions = new List<Produce> { Get("Basil") } });
            Add(new Produce { Name = "Lime", Cost = 1.0m, Measurement = "Whole", Substitutions = new List<Produce> { Get("Lemon"), Get("Orange"), Get("Grapefruit") } });
            Add(new Produce { Name = "Green Apple", Cost = 1.0m, Measurement = "Whole", Substitutions = new List<Produce> { Get("Pear") } });
            Add(new Produce { Name = "Cucumber", Cost = 1.0m, Measurement = "Whole", Substitutions = new List<Produce> { Get("Celery") } });
            Add(new Produce { Name = "Head of Green Cabbage", Cost = 1.0m, Measurement = "Whole", Substitutions = new List<Produce> { Get("Kale"), Get("Broccoli") } });
            Update(new Produce { Name = "Pear", Cost = 1.0m, Measurement = "Whole", Substitutions = new List<Produce> { Get("Green Apple"), Get("Pineapple") } });
        }

        public IDictionary<string, Produce> GetAll()
        {
            return _produce;
        }

        public Produce Get(string name)
        {
            if (!_produce.ContainsKey(name))
            {
                throw new KeyNotFoundException("No produce exists with the name " + name);
            }

            return _produce[name];
        }

        public void Add(Produce produce)
        {
            _produce.Add(produce.Name, produce);
        }
        public void Remove(string id)
        {
            _produce.Remove(id);
        }

        public void Update(Produce produce)
        {
            _produce.Remove(produce.Name);
            _produce.Add(produce.Name, produce);
        }
    }
}
