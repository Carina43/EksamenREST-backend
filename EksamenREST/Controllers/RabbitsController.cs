using EksamenREST.Model;
using EksamenREST.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EksamenREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitsController : ControllerBase
    {
        private readonly RabbitsRepository _repository;
        public RabbitsController(RabbitsRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Rabbits
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult<IEnumerable<Rabbit>> Get()
        {
            return Ok(_repository.GetAll());
        }

        // GET api/Rabbits/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Rabbit> GetById(int id)
        {
            var rabbit = _repository.GetById(id);

            if (rabbit == null)
            {
                return NotFound();
            }

            return Ok(rabbit);
        }

        // fjern nullcheck
        // POST: api/Rabbits
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public ActionResult<Rabbit> Post([FromBody] Rabbit value)
        {

            //if (value == null)
            //{
            //    return BadRequest();
            //}

            var created = _repository.Add(value);

            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                created
            );
        }

        // DELETE api/Rabbits/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public ActionResult Delete(int id)
        {
            var deleted = _repository.Delete(id);

            if (deleted == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
