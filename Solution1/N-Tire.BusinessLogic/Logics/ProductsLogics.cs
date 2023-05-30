using AutoMapper;
using Microsoft.EntityFrameworkCore;
using N_Tier.BusinessLogic.Abstractions;
using N_Tier.Data.DAL;
using N_Tire.BusinessLogic.Abstractions;
using N_Tire.BusinessLogic.Models.DTO.Product;
using N_Tire.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.BusinessLogic.Logics
{
    public class ProductsLogics: IProductsLogics
    {
        private readonly IGenericRepository<Product> _productRepostitory;
        public ProductsLogics(IGenericRepository<Product> productRepostitory)
        { 
            _productRepostitory = productRepostitory;
        }
        public async Task<List<GetProductUIDTO>> ProductList()
        {
            List<GetProductUIDTO> p = new List<GetProductUIDTO>();
            List<Product> products = await _productRepostitory.GetAll();
            foreach(var product in products)
            {
                p.Add(new GetProductUIDTO { Name = product.Name , Color = product.Color, Price = product.ProductPrice});
            }
            return p;
        }

        public async Task<bool> AddProduct(AddProductUIDTO p)
        {
            if(p != null)
            {
                Product product = new Product { Name= p.Name, Color = p.Color, ProductPrice = p.Price};
                await _productRepostitory.AddAndCommit(product);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateProduct(UpdateProductUIDTO p)
        {
            var product = await _productRepostitory.GetById(p.Id);
            if(product != null)
            {
                product.Name = p.Name;
                product.Color = p.Color;
                product.ProductPrice = p.Price;
                await _productRepostitory.Commit();
                return true;
            }else
            {
                return false;
            }
        }

        public async Task<Product> ProductById(int id)
        {
            var product = await _productRepostitory.GetById(id);
            return product;
        }

        public async Task<bool> Deleteproduct(DeleteProductUIDTO p)
        {
            if(p != null)
            {
                var product = await _productRepostitory.GetById(p.Id);
                if( product != null)
                {
                    _productRepostitory.Delete(product);
                    await _productRepostitory.Commit();
                }
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
