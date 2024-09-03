using ASP_CORE_API.Data;
using ASP_CORE_API.DTO;
using ASP_CORE_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_CORE_API.Repositories.ProductRepository
{
    public class ProductRepositoryImpl : IProductRepositorycs
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ProductRepositoryImpl(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }
        public Product Create(ProductDTO productDTO)
        {
            Product product = new Product();
            product.Name = productDTO.Name;
            product.Description = productDTO.Description;
            product.status = productDTO.status;
            product.Price = productDTO.Price;
            product.CategoryId = productDTO.CategoryId;
            product =  _applicationDbContext.Products.Add(product).Entity;
            _applicationDbContext.SaveChanges();
            return product;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            try
            {
                List<Product> products = _applicationDbContext.Products.Include(p=> p.Category).ToList();
                return products;
            }
            catch (Exception ex) {
                throw new Exception("get data product fales repository " + ex);
            }
        }

        public Product GetProduct(int id)
        {
            try
            {
                Product product = _applicationDbContext.Products.Where(p => p.Id == id).FirstOrDefault();
                return product;
            }catch(Exception ex)
            {
                throw new Exception("Det data product false repository " + ex);
            }
        }

        public Product Save(Product product, int id)
        {
            try
            {
                Product productUpdate = _applicationDbContext.Products.Update(product).Entity;
                return productUpdate;
            }
            catch (Exception ex) {
                throw new Exception("Update false repository " + ex);
            }
        
        }
    }
}
