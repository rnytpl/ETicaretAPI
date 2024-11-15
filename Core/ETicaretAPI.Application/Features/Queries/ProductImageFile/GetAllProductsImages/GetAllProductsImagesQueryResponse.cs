using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.ProductImageFile.GetAllProductsImages
{
    public class GetAllProductsImagesQueryResponse
    {
        public int TotalProductCount { get; set; }
        public decimal TotalPages { get; set; }
        public object Products { get; set; }

    }

    public class Products
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public float? Price { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public List<ProductImages> ProductImages { get; set; }
    }

    public class ProductImages
    {

        public string FileName { get; set; }
        public string Path { get; set; }
    }

}
