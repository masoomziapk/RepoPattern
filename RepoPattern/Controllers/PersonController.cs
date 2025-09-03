using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoPattern.Entity;
using RepoPattern.ServiceDefination;
using System.Threading.Tasks;

namespace RepoPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("GetAllPerson")]
        public IActionResult  GetAllPerson()
        {
            var persons =  _personService.GetAllPerson();
            return Ok(persons);
        }

        [HttpGet("GetById")]
        public IActionResult GetPersonById(int id)
        {
           var person = _personService.GetPersonById(id);
            
            return Ok(person);
        }

        [HttpPost("AddPerson")]
        public IActionResult SavePersonInfo(List<Person> personInfo)
        {
             bool isSaved = _personService.SavePersonInfo(personInfo);
            if (isSaved)
                {
                return Ok("Person info saved successfully.");
            }
            return BadRequest("Failed to save person info.");

        }
        [HttpPut("UpdatePerson")]
        public IActionResult UpdatePersonInfo(Person person)
        {
            var isUpdated = _personService.UpdatePersonInfo(person);
            if (isUpdated)
            {
                return Ok("Person info updated successfully.");
            }
            return BadRequest("Failed to update person info.");

        }
        [HttpDelete("DeletePerson")]
        public IActionResult DeletePersonById(int id)
        {
            var isDeleted = _personService.DeletePersonById(id);
            if (isDeleted)
            {
                return Ok("Person info deleted successfully.");
            }
            return BadRequest("Failed to delete person info.");
        }
    }

        
}
