using Microsoft.AspNetCore.Mvc;
using TetPee.Service.Category;

namespace TestRepo.Api.Controller;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IService _categoryService;

    public CategoryController(IService categoryService)
    {
        _categoryService = categoryService;
    }
    
    [HttpPost("")]
    public async Task<IActionResult> CreateCategory(Request.CategoryRequest request)
    {
        var result = await _categoryService.CreateCategory(request);
        return Ok(result);
    }

    [HttpGet("")]
    public async Task<IActionResult> GetCategories()
    {
        var result = await _categoryService.GetAllCategories();
        return Ok(result);
    }
    [HttpGet("{parentId}/children")]
    public async Task<IActionResult> GetAllChildrenCategory(Guid parentId)
    {
        var result = await _categoryService.GetAllChildrenCategory(parentId);
        return Ok(result);
    }
}