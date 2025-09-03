using RepoPattern.Entity;

namespace RepoPattern.ServiceDefination
{
    public interface IPersonService
    {
        public bool SavePersonInfo(List<Person> PersonInfo);
        public Person GetPersonById(int Id);
        public List<Person> GetAllPerson();
        public bool UpdatePersonInfo(Person person);
        public bool DeletePersonById(int Id);
    }
}
