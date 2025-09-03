using RepoPattern.Connections;
using RepoPattern.Entity;
using RepoPattern.RepositoryDefination;

namespace RepoPattern.Repository
{
    public class PersonRepository : IPersonReposatory
    {
        private readonly AppDbContext _context;

        public PersonRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool SavePersonInfo(List<Person> PersonInfo)
        {
            _context.Persons.AddRange(PersonInfo);
            _context.SaveChanges();
            return true;
        }
        public bool DeletePersonById(int Id)
        {
            var person = _context.Persons.Find(Id);

            if (person == null)
            {
                return false;
            }

            _context.Persons.Remove(person);
            _context.SaveChanges();
            return true;
        }

        public List<Person> GetAllPerson()
        {
            return _context.Persons.ToList();
        }

        public Person GetPersonById(int Id)
        {
            var person = _context.Persons.Find(Id);
            return person;
        }

        public bool UpdatePersonInfo(Person person)
        {
            var existingPerson = _context.Persons.Find(person.Id);
            if (existingPerson == null)
            {
                return false;
            }
            existingPerson.Name = person.Name;
            existingPerson.Age = person.Age;
            existingPerson.Email = person.Email;
            existingPerson.Address = person.Address;
            _context.SaveChanges();
            return true;
        }
    }
}
