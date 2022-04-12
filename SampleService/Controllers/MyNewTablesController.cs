using Microsoft.AspNetCore.Mvc;
using MyPCL;
using MyPCL.Repositories;
using System.Threading.Tasks;

namespace SampleService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyNewTablesController : BaseController<MyNewTable, MyNewTableRepository>
    {
        private readonly MyNewTableRepository _repository;

        public MyNewTablesController(MyNewTableRepository repository) : base(repository)
        {
            _repository = repository;
        }

        [HttpGet("HelloWorld")]
        public async Task<ActionResult<string>> HelloWorld()
        {
            var myDataToReturn = "Hello, World";

            return Ok(myDataToReturn);
        }

        [HttpGet("GetWelcome/{welcomeType}")]
        public async Task<ActionResult<string>> GetWelcome(string welcomeType)
        {
            var welcomeTypeRecord = await _repository.GetWelcomeByWelcomeTypeName(welcomeType);

            if(welcomeTypeRecord == null)
                return NotFound();

            return Ok(welcomeTypeRecord.MyField);
        }
    }
}
