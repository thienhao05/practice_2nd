namespace TetPee.Service.Category;

public interface IService
{
    public Task<string> CreateCategory(Request.CategoryRequest request);
    public Task<List<Response.CategoryResponse>> GetAllCategories();
    public Task<List<Response.CategoryResponse>> GetAllChildrenCategory(Guid parentId);
}