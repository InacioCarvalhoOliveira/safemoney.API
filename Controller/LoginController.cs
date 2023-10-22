namespace Name.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using safemoney.API.Contracts;
    using safemoney.API.Services;
    using safemoney.API.Entities;
    using safemoney.API.Models;

    [Route("api/[Controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly TokenService _tokenService;
        private readonly ILogger<LoginToken> _logger;

        private readonly IloginToken _loginToken; // Injete a dependência LoginToken
        // Injete a dependência no construtor
        public LoginController(IloginToken loginToken, ILogger<LoginToken> logger)
        {
            _loginToken = loginToken;
            _tokenService = new TokenService("ScoutTro0per.FGV23", "JWT", "Safemoney.API");
            _logger = logger;
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUserToken(User user)
        {
            try
            {
                // Chama o método CreateUserToken da classe LoginToken para inserir os dados do usuário no banco de dados.
                string token = _tokenService.GenerateToken(user);
                
                 _loginToken.CreateUserToken(user);
                // Retorne o token JWT como resposta.
                return Ok(new { user,token });

            }
            catch (Exception ex)
            {
               // Log de erro ou manipulação de exceção adequada
                _logger.LogError(ex, "Ocorreu um erro ao criar o token do usuário");

                // Verifica se a exceção é devido a um usuário duplicado e retorna um status 409 (Conflito)
                if (ex.Message.Contains("Usuário duplicado", StringComparison.OrdinalIgnoreCase))
                {
                    return StatusCode(409, "Usuário duplicado");
                }

                return StatusCode(500, "Erro ao criar token do usuário");
            }
        }
        [HttpGet("ListUsers")]
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

        [HttpGet("{userId}", Name = "GetUserById")]
        public ActionResult GetuserById(string userId)
        {
            try
            {
                var userByid = _loginToken.GetUserById(userId).Result; // Obtenha a lista de usuários sincronamente
                if (userByid == null) { return NotFound("não encontrado"); }
                return Ok(userByid);
            }
            catch (Exception ex)
            {
                // Log de erro ou manipulação de exceção adequada
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("{userid}")]
        public async Task<IActionResult> UpdateUser(string userid, User user)
        {
            try
            {
                var updateUser = await _loginToken.GetUserById(userid);
                if (updateUser == null)
                    return NotFound();
                await _loginToken.UpdateUserById(userid, user);
                return StatusCode(200, $"Usuario {user.NAMEUSER} atualizado com sucesso");
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteCompany(int id)
        // {
        //     try
        //     {
        //         var dbCompany = await _companyRepo.GetCompany(id);
        //         if (dbCompany == null)
        //             return NotFound();
        //         await _companyRepo.DeleteCompany(id);
        //         return NoContent();
        //     }
        //     catch (Exception ex)
        //     {
        //         //log error
        //         return StatusCode(500, ex.Message);
        //     }
        // }
        

    }
}
