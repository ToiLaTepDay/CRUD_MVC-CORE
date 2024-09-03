using ASP_CORE_API.Models;
using ASP_CORE_API.DTO;
namespace ASP_CORE_API.Services.Products
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetProduct(int id);
        Product Create(ProductDTO productDTO);
        Product Save(Product product, int id);
        void Delete(int id);    
    }
}
