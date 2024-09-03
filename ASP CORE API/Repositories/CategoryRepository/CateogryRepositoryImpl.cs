using ASP_CORE_API.Data;
using ASP_CORE_API.DTO;
using ASP_CORE_API.Models;

namespace ASP_CORE_API.Repositories
{
    public class CateogryRepositoryImpl :ICategoryRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CateogryRepositoryImpl (ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;  
        }

        public Category Create(CategoryDTO categoryDTO)
        {
            try
            {
                Category category = new Category();
                category.Name = categoryDTO.Name;
                category.Description = categoryDTO.Description;
                category = _applicationDbContext.Categories.Add(category).Entity;
                _applicationDbContext.SaveChanges();
                return category;
            }
            catch (Exception ex)
            {
                throw new Exception("Can not data repository " + ex);
            }
        }

        public void Delete(int id)
        {
           Category category = _applicationDbContext.Categories.Where(c => c.Id == id).FirstOrDefault();
            _applicationDbContext.Remove(category);
            _applicationDbContext.SaveChanges();
        }

        public List<Category> GetAll()
        {
            try
            {
                List<Category> categories = _applicationDbContext.Categories.ToList();
                return categories;
            }
            catch (Exception ex) {
                throw new Exception("Can not data repository "+ex);
            }
        }

        public Category GetById(int id)
        {
            try
            {
                Category category = _applicationDbContext.Categories.Where(category => category.Id == id).FirstOrDefault();
                return category;
            }
            catch (Exception ex) {
                throw new Exception("Can not data repository " + ex);
            }
        }

        public Category save(Category category, int id)
        {
            Category categoryUpdate = _applicationDbContext.Categories.Update(category).Entity;
            _applicationDbContext.SaveChanges();
            return categoryUpdate;
        }
    }
}
