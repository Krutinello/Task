using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using People.Dal.Abstract;
using People.Dal.Entities;

namespace Task.Controllers
{
    [Produces("application/json")]
    [Route("api/People")]
    public class PeopleController : Controller
    {
        private readonly IPeopleRepository _peopleRepository;

        public PeopleController(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository ?? throw new ArgumentNullException(nameof(peopleRepository));
        }

        // GET api/values
        /// <summary>
        /// The list of all people
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Person> Get() => _peopleRepository.Get();

        // GET api/values/5
        /// <summary>
        /// This will provide details for specific ID which is begin passed
        /// </summary>
        /// <param name="id">Mandatory</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Person person = _peopleRepository.GetById(id);
            if (person != null)
                return Ok(person);

            return NotFound();
        }

        /// <summary>
        /// Adding new person into People list
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody]Person person)
        {
            if (ModelState.IsValid)
            {
                _peopleRepository.Add(person);
                return Ok();
            }

            return BadRequest();
        }

        /// <summary>
        /// Editing person by ID
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]Person person)
        {
            if (ModelState.IsValid)
            {
                Person p = _peopleRepository.GetById(person.Id);
                if (p != null)
                {
                    _peopleRepository.Update(p);
                    return Ok();
                }

                return NotFound();
            }

            return BadRequest();
        }

        /// <summary>
        /// Removeing person from people list
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Person person = _peopleRepository.GetById(id);
            if (person != null)
            {
                _peopleRepository.Delete(id);
                return Ok();
            }

            return NotFound();
        }
    }
}