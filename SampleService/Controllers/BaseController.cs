using Microsoft.AspNetCore.Mvc;
using MyPCL;
using MyPCL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TEntity, TRepository> : ControllerBase
        where TEntity : BaseEntity
        where TRepository : IRepository<TEntity>
    {
        private readonly TRepository _repository;

        public BaseController(TRepository repository)
        {
            _repository = repository;
        }

        // GET: api/[controller]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            return await _repository.GetAll();
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            var entity = await _repository.Get(id);

            if (entity == null)
                return NotFound();

            return entity;
        }

        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TEntity entity)
        {
            if (id != entity.Id)
                return BadRequest($"Request failed due to an ID mismatch. Request ID: {id}, Entity ID: {entity.Id}, Entity type: {entity.GetType().Name}");

            await _repository.Update(entity);

            return CreatedAtAction("Get", new { id = entity.Id }, entity);
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity entity)
        {
            await _repository.Add(entity);
            return CreatedAtAction("Get", new { id = entity.Id }, entity);
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(int id)
        {
            var entity = await _repository.Delete(id);

            if (entity == null)
                return NotFound();

            return entity;
        }
    }
}
