using ASP_CORE_API.Services.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASP_CORE_API.Models;
using ASP_CORE_API.DTO;

namespace ASP_CORE_API.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService) { 
            this._productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult>  GetAll() {
            try
            {
                var listProduct = _productService.GetAll();
                return Ok(new
                {
                    message = "Get data success",
                    data = listProduct
                });
            }
            catch (Exception ex) {
                throw new Exception("get data false controller " + ex);
            }
        }

        [HttpPost]
        public IActionResult Create(ProductDTO productDTO)
        {
            try
            {
                Product product = _productService.Create(productDTO);
                return Ok(new
                {
                    message = "Create Product Success",
                    data = product
                });
            }catch(Exception ex)
            {
                throw new Exception("Create Product Controller " + ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            try
            {
                Product product = _productService.GetProduct(id);
                if (product == null) {
                    return NotFound();
                }
                return Ok(new
                {
                    message="Find success",
                    data = product  
                });
            }
            catch (Exception ex) {
                throw new Exception("get data false controller" + ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct (int id, Product product)
        {
            try
            {
                Product productUpdate = _productService.Save(product, id);
                if (productUpdate == null) {
                    return NotFound();
                }
                return Ok(new
                {
                    message = "Update success",
                    data = productUpdate    
                });
            }
            catch (Exception ex) {
                throw new Exception("update data false controller" + ex);

            }
        }

    }
}
