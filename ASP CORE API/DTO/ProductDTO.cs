using ASP_CORE_API.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_CORE_API.DTO
{
    public class ProductDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public bool status { get; set; }
    }
}
