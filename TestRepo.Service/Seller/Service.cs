using Microsoft.EntityFrameworkCore;
using TetPee.Repository;

namespace TetPee.Service.Seller;

public class Service : IService
{
    private readonly AppDbContext _dbContext;

    public Service(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string> CreateSeller(Request.SellerRequest request)
    {
        var existingUser = _dbContext.Users.Where(x => x.Email == request.Email);
        var isExistUser = await existingUser.AnyAsync();
        if(isExistUser)
            throw new Exception("User exists");
        var user = new Repository.Entity.User()
        {
            Email = request.Email,
            Password = request.Password,
            Role = "Seller"
        };

        _dbContext.Add(user);
        await _dbContext.SaveChangesAsync();
        var seller = new Repository.Entity.Seller()
        {
            UserId = user.Id,
            TaxCode = request.TaxCode,
            CompanyAddress = request.CompanyAddress,
            CompanyName = request.CompanyName,
        };
        _dbContext.Add(seller);
        await _dbContext.SaveChangesAsync();
        return "Add Seller successfully";
    }
}