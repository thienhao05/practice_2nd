using Microsoft.AspNetCore.Mvc;
using TetPee.Service.Seller;

namespace TestRepo.Api.Controller;

[ApiController]
[Route("[controller]")]
public class SellerController : ControllerBase
{
    private readonly IService _sellerService;

    public SellerController(IService sellerService)
    {
        _sellerService = sellerService;
    }
    
    [HttpPost("")]
    public async Task<IActionResult> CreateSeller(Request.SellerRequest request)
    {
        var result = await _sellerService.CreateSeller(request);
        return Ok(result);
    }
}