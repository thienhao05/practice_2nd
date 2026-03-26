using Microsoft.AspNetCore.Mvc;
using TetPee.Service.User;

namespace TestRepo.Api.Controller;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IService _userService;
    public UserController(IService userService)
    {
        _userService = userService;
    }
    
    [HttpPost("")]
    public async Task<IActionResult> CreateCategory(Request.UserRequest request)
    {
        var result = await _userService.CreateUser(request);
        return Ok(result);
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAllCategories(string ? searchTerm, int pageSize = 10, int pageIndex = 1)
    {
        var result = await _userService.GetAllUsers(searchTerm, pageSize, pageIndex);
        return Ok(result);
    }
}