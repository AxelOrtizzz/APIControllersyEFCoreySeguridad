using Microsoft.AspNetCore.Mvc;
using BankAPI.Services;
using BankAPI.Data;
using BankAPI.Data.BankModels;

namespace BankAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly LoginService loginService;

    public LoginController(LoginService loginService)
    {
        this.loginService = loginService;
    }

    [HttpPost]
    public async Test<IActionResult> Login(AdminDto adminDto)
    {
        var admin = await loginService.GetAdmin(adminDto);

        if(admin is null)
            return BadRequest(new {message = "Credenciales invalidas"});
        
        //Generar token

        return Ok(new {token = "some value"});
    }
}
