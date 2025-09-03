using RepoPattern.Entity;
using RepoPattern.RepositoryDefination;
using RepoPattern.ServiceDefination;

namespace RepoPattern.Service
{
    public class PersonService : IPersonService
    {
        private readonly IPersonReposatory _personRepository;
        public PersonService(IPersonReposatory personRepository)
        {
            _personRepository = personRepository;
        }
        public bool DeletePersonById(int Id)
        {
            _personRepository.DeletePersonById(Id);
            return true;
        }

        public List<Person> GetAllPerson()
        {
            return _personRepository.GetAllPerson();
            
        }

        public Person GetPersonById(int Id)
        {
           return _personRepository.GetPersonById(Id);
            
        }

        public bool SavePersonInfo(List<Person> PersonInfo)
        {
            _personRepository.SavePersonInfo(PersonInfo);
            return true;
        }

        public bool UpdatePersonInfo(Person person)
        {
          _personRepository.UpdatePersonInfo(person);
            return true;
        }
    }
}
