using N_Tire.BusinessLogic.Models.DTO.Product;
using N_Tire.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.BusinessLogic.Abstractions
{
    public interface IProductsLogics
    {
        Task<List<GetProductUIDTO>> ProductList();
        Task<bool> AddProduct(AddProductUIDTO p);
        Task<bool> UpdateProduct(UpdateProductUIDTO p);
        Task<Product> ProductById(int id);
        Task<bool> Deleteproduct(DeleteProductUIDTO p);
    }
}
