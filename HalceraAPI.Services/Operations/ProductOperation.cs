﻿using HalceraAPI.DataAccess.Contract;
using HalceraAPI.Models;
using HalceraAPI.Models.Requests.Product;
using HalceraAPI.Services.Contract;

namespace HalceraAPI.Services.Operations
{
    public class ProductOperation : IProductOperation
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductOperation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Add product item to cart
        /// </summary>
        /// <param name="productId">id of product</param>
        /// <returns>id of product in cart</returns>
        public async Task<int> AddProductToCart(int productId)
        {
            try
            {
                ShoppingCart? cart = await _unitOfWork.ShoppingCart.GetFirstOrDefault(cart => cart.ProductId == productId);
                if (cart == null)
                {   // adds new item in cart
                    Product? productItem = await _unitOfWork.Product.GetFirstOrDefault(product => product.Id == productId);
                    if (productItem == null)
                    {
                        throw new Exception("Product not found");
                    }
                    // TODO: add ApplicationUser from Token
                  //  cart = new ShoppingCart() { ProductId = productId, Price = productItem.Price };
                    // if product item does not exist in cart, add new item
                    await _unitOfWork.ShoppingCart.Add(cart);
                }
                else
                {   // update existing item count in cart
                    cart.Count++;
                }
                await _unitOfWork.SaveAsync();
                return cart.Id;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public async Task<Product> CreateProduct(CreateProductRequest product)
        {
            try
            {
                // TODO: validate category
                //await _unitOfWork.Product.Add(product);
                //await _unitOfWork.SaveAsync();
                return new();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Product? productDetails = await _unitOfWork.Product.GetFirstOrDefault(product => product.Id == productId);
                if (productDetails == null)
                    throw new Exception("Product not found");
                _unitOfWork.Product.Remove(productDetails);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        /// Gets All products
        /// </summary>
        /// <returns>List of Products</returns>
        public async Task<IEnumerable<Product>?> GetAllProducts(bool isActive)
        {
            try
            {
                IEnumerable<Product>? listOfProducts = await _unitOfWork.Product.GetAll(includeProperties: "Category");
                return listOfProducts;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        /// Get a single product by Id
        /// </summary>
        /// <param name="id">Id of product to be returned</param>
        /// <returns>Product</returns>
        public async Task<Product?> GetProductById(int productId)
        {
            try
            {
                Product? product = await _unitOfWork.Product.GetFirstOrDefault(product => product.Id == productId);
                return product;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public async Task<Product> UpdateProduct(CreateProductRequest product)
        {
            try
            {
                Product? productFromDb = await _unitOfWork.Product.GetFirstOrDefault(productDetails => productDetails.Id == 0);
                if (productFromDb == null) throw new Exception("Product not found");

                //productFromDb.Title = product.Title ?? productFromDb.Title;

                _unitOfWork.Product.Update(productFromDb);
                await _unitOfWork.SaveAsync();

                return productFromDb;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
