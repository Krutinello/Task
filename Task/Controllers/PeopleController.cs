using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.Models.MyModels;

namespace Task.Controllers
{
    [Produces("application/json")]
    [Route("api/People")]
    public class PeopleController : Controller
    {
        private static List<PersonModel> people;
        static PeopleController()
        {

            people = new List<PersonModel>()
            {
                new PersonModel(){Id=1, Name="Andrew",SurName="Kur",Age=33},
                new PersonModel(){Id=2, Name="Alex",SurName="Test",Age=23},
                new PersonModel(){Id=3, Name="Anna",SurName="LastName",Age=20},
                new PersonModel(){Id=4, Name="Olga",SurName="Kos",Age=34}
            };
        }
        public PeopleController()
        {         
        }
        // GET api/values
        /// <summary>
        /// The list of all people
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<PersonModel> Get()
        {
            //return new string[] { "value1", "value2" };
            return people;
        }

        // GET api/values/5
        /// <summary>
        /// This will provide details for specific ID which is begin passed
        /// </summary>
        /// <param name="id">Mandatory</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var person = people.Find(m => m.Id == id);
            if (person != null)
            {
                return Ok(person);
            }
            else
            {
                return StatusCode(404);
            }
            
            //return NotFound("Ресурс в приложении не найден");
        }

        /// <summary>
        /// Adding new person into People list
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody]PersonModel person)
        {
            if (ModelState.IsValid)
            {
                people.Add(person);
                return Ok();
            }
            else
            {
                return StatusCode(404);
            }
        }

        /// <summary>
        /// Editing person by ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]PersonModel person)
        {
            if (ModelState.IsValid)
            {
                var _person = people.Find(m=>m.Id==id);
                if (_person != null)
                {
                    _person.Name = person.Name;
                    _person.SurName = person.SurName;
                    _person.Age = person.Age;
                    return Ok();
                }
                else
                {
                    return StatusCode(404);
                }
            }
            else
            {
                return StatusCode(404);
            }
        }

        /// <summary>
        /// Removeing person from people list
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var person = people.Find(m => m.Id == id);
            if (person != null)
            {
                people.Remove(person);
                return Ok();
            }
            else
            {
                return StatusCode(404);
            }
        }
    }
}