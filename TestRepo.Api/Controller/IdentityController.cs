using Microsoft.AspNetCore.Mvc;
using TetPee.Service.Identity;

namespace TestRepo.Api.Controller;

[ApiController]
[Route("[controller]")]
public class IdentityController : ControllerBase
{
    private readonly IService _identityService;

    public IdentityController(IService identityService)
    {
        _identityService = identityService;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(Request.LoginRequest loginRequest)
    {
        var newUser = await _identityService.Login(loginRequest);
        return Ok(newUser);
    }
}