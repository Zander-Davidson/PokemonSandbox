using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Neo4j.Driver;

namespace PokemonSandbox
{
    [ApiController]
    [Route("[controller]")]
    public class TypesController : ControllerBase
    {
        private readonly ILogger<TypesController> _logger;
        private readonly IDriver _driver;

        public TypesController(ILogger<TypesController> logger, IDriver driver)
        {
            _logger = logger;
            _driver = driver;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            IResultCursor cursor;
            var types = new List<string>();
            IAsyncSession session = _driver.AsyncSession();
            try 
            {
                cursor = await session.RunAsync(@"MATCH (t:Type) RETURN t.name AS name");
                types = await cursor.ToListAsync(record => record["name"].As<string>());
            }
            finally
            {
                await session.CloseAsync();
            }

            return Ok(types);
        }
    }
}
