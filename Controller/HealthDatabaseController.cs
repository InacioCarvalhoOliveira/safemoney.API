using Microsoft.AspNetCore.Mvc;
using safemoney.API.Models;

namespace safemoney.API.Controller
{
    [Route("api/Health")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private readonly DatabaseChecker _databaseChecker;

        public DatabaseController(DatabaseChecker databaseChecker)
        {
            _databaseChecker = databaseChecker;
        }

        [HttpGet("connection")]
        public IActionResult GetConnectionInfo()
        {
            bool isConnected = _databaseChecker.IsDatabaseConnected();

            if (isConnected)
            {
                return StatusCode(200,"A conexão com o banco de dados está disponível.");
            }
            else
            {
                return StatusCode(500, "Não foi possível conectar ao banco de dados{}.");
            }
        }

        [HttpGet("status")]
        public IActionResult CheckDatabaseStatus()
        {
            bool isConnected = _databaseChecker.IsDatabaseConnected();

            if (isConnected)
            {
                return Ok("A conexão com o banco de dados foi estabelecida com sucesso.");
            }
            else
            {
                return StatusCode(500, "Não foi possível conectar ao banco de dados.");
            }
        }
    }
}
