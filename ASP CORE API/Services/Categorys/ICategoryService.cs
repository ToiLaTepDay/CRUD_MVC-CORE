using ASP_CORE_API.DTO;
using ASP_CORE_API.Models;

namespace ASP_CORE_API.Services.Categorys
{
    public interface ICategoryService
    {
         List<Category> FindAll();
        Category Create(CategoryDTO categoryDTO);   
         Category GetCategoryByid(int id);
         Category Save(Category category, int id);

         void DeleteById(int id);

    }
}
