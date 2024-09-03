using ASP_CORE_API.DTO;
using ASP_CORE_API.Models;
using ASP_CORE_API.Repositories.ProductRepository;

namespace ASP_CORE_API.Services.Products
{
    public class ProductServiceImpl : IProductService
    {
        private readonly IProductRepositorycs _productRepositorycs;
        public ProductServiceImpl(IProductRepositorycs productRepositorycs) { 
            this._productRepositorycs = productRepositorycs;
        }
        public Product Create(ProductDTO productDTO)
        {
            try
            {
                Product product = _productRepositorycs.Create(productDTO);
                return product;
            }
            catch (Exception ex) {
                throw new Exception("get data false service " + ex);
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            try
            {
                List<Product> products = _productRepositorycs.GetAll();
                return products;
            }
            catch(Exception ex)
            {
                throw new Exception("get data false product service" + ex);
            }
           
        }

        public Product GetProduct(int id)
        {
            try
            {
                Product product  = _productRepositorycs.GetProduct(id); 
                return product;
            }catch(Exception ex)
            {
                throw new Exception("Get data false service " + ex);
            }
        }

        public Product Save(Product product, int id)
        {
            try
            {
                Product productUpdate = _productRepositorycs.Save(product, id);
                return productUpdate;
            }catch(Exception ex)
            {
                throw new Exception("update data false service " + ex);
            }
        }
    }
}
