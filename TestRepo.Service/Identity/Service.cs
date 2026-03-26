using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TetPee.Repository;
using TetPee.Service.JwtService;

namespace TetPee.Service.Identity;

public class Service : IService
{
    private readonly AppDbContext _dbContext;
    private readonly JwtOptions _jwtOption = new();
    private readonly JwtService.IService _jwtService;

    public Service(IConfiguration configuration, AppDbContext dbContext, JwtService.IService tokenService)
    {
        _dbContext = dbContext;
        _jwtService = tokenService;
        configuration.GetSection(nameof(JwtOptions)).Bind(_jwtOption);
    }


    public async Task<Response.LoginResponse> Login(Request.LoginRequest request)
    {

        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
        if (user == null)
        {
            throw new Exception("User not found");
        }

        if (user.Password != request.Password)
        {
            throw new Exception("Wrong password");
        }

        var claims = new List<Claim>()
        {
            new Claim("UserId", user.Id.ToString()),
            new Claim("Email", user.Email),
            new Claim(ClaimTypes.Role, user.Role),
        };
        var token = _jwtService.GenerateAccessToken(claims);
        return new Response.LoginResponse()
        {
            AccessToken = token,
        };
    }
}