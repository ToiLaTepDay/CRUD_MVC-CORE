using ASP_CORE_API.DTO;
using ASP_CORE_API.Models;

namespace ASP_CORE_API.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category Create(CategoryDTO categoryDTO);
        Category GetById(int id);
        Category save(Category category, int id);
        void Delete(int id);
    }
}
