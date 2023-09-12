namespace Name.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using safemoney.API.Contracts;
    using safemoney.API.Services;
    using safemoney.API.Entities;

    [Route("api/[Controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IloginToken _loginToken; // Injete a dependência LoginToken
        // Injete a dependência no construtor
        public LoginController(IloginToken loginToken)
        {
            _loginToken = loginToken;
        }

        [HttpPost]
        public IActionResult CreateUserToken(User user)
        {
            try
            {
                var tokenService = new TokenService(secretKey: "ScoutTro0per.FGV23", issuer: "JWT", audience: "Safemoney.API");
                string token = tokenService.GenerateToken(user);
                // Chama o método CreateUserToken da classe LoginToken para inserir os dados do usuário no banco de dados.
                _loginToken.CreateUserToken(user);
                // Retorne o token JWT como resposta.
                return Ok(new {user,token});

            }
            catch (Exception ex)
            {
                // Log de erro ou manipulação de exceção adequada
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("ListAllUsers")]
        public IActionResult ListUsers()
        {
            try
            {
                // Chama o método GetUsers da classe LoginToken para listar os usuários.
                var users = _loginToken.GetUsers().Result; // Obtenha a lista de usuários sincronamente
                return Ok(users);
            }
            catch (Exception ex)
            {
                // Log de erro ou manipulação de exceção adequada
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{token}")]
        public IActionResult GetuserByToken()
        {
            try
            {
                // Chama o método GetUsers da classe LoginToken para listar os usuários.
                var users = _loginToken.GetUsers().Result; // Obtenha a lista de usuários sincronamente
                return Ok(users);
            }
            catch (Exception ex)
            {
                // Log de erro ou manipulação de exceção adequada
                return StatusCode(500, ex.Message);
            }
        }

    }
}
