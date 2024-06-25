using Application.Models.Requests;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        
        private readonly IAuthenticationService _authenticationService;

        
        public AuthenticationController(IAuthenticationService autenticacionService)
        {
            
            _authenticationService = autenticacionService;
        }

        [HttpPost("[action]")] 
        public ActionResult<string> Autenticar([FromBody] AuthenticationRequest authenticationRequest) //Enviamos como parámetro la clase que creamos arriba
        {
            try
            {
                string token = _authenticationService.Autenticar(authenticationRequest);
                return Ok(token);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }

    }
}
