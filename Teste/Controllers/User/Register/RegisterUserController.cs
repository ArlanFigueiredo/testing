using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teste.Application.UseCases.User.Register;
using Teste.Communication.Model.User;
using Teste.Communication.Requests.User;
using Teste.Communication.Responses.User;

namespace Teste.Controllers.User.Register {
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterUserController : ControllerBase {

        [HttpPost]
        [ProducesResponseType(typeof (ResponseRegisterUser), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Register([FromBody] ModelUser request) {


            try {
                var useCase = new RegisterUserUseCase().Execute(request);
                return Created(string.Empty, useCase.Result.Message);
            }
            catch (Exception ex) { 
            
                if(ex is Exception) {

                    return BadRequest(ex.Message);
                }
            
            }

            return Created();
        }
    }
}
