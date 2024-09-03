using ASP_CORE_API.DTO;
using ASP_CORE_API.Models;
using ASP_CORE_API.Repositories;


namespace ASP_CORE_API.Services.Categorys
{
    public class CategoryServiceImpl : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryServiceImpl(ICategoryRepository categoryRepository) { 
            this._categoryRepository = categoryRepository;  
        }

        public Category Create(CategoryDTO categoryDTO)
        {
            try
            {
                Category  category = _categoryRepository.Create(categoryDTO);
                return category;
            }
            catch (Exception ex)
            {
                throw new Exception("Can not data service  " + ex);
            }
        }

        public void DeleteById(int id)
        {
            _categoryRepository.Delete(id);
        }

        public List<Category> FindAll()
        {
            try
            {
                List<Category> list = _categoryRepository.GetAll();
                return list;
            }
            catch (Exception ex) {
                throw new Exception("Can not data service  " + ex);
            }
        }

        public Category GetCategoryByid(int id)
        {
            try
            {
                Category category = _categoryRepository.GetById(id);
                return category;
            }
            catch (Exception ex)
            {
                throw new Exception("Can not data service  " + ex);
            }
        }

        public Category Save(Category category, int id)
        {
            Category categoryUpdate = _categoryRepository.save(category, id);
            return categoryUpdate;
        }
    }
}
