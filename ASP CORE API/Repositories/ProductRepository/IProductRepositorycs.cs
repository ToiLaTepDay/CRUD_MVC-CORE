using ASP_CORE_API.DTO;
using ASP_CORE_API.Models;

namespace ASP_CORE_API.Repositories.ProductRepository
{
    public interface IProductRepositorycs
    {
        List<Product> GetAll();
        Product GetProduct(int id);
        Product Create(ProductDTO productDTO);
        Product Save(Product product, int id);
        void Delete(int id);
    }
}
