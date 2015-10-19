#region Namespaces....
using AutoMapper;
using BusinessEntities;
using DataModel.Entity;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
#endregion


namespace BusinessServices
{
   public class ProductServices : IProductServices
    {
        /// <summary>
        /// Offers services for product specific CRUD operations
        /// </summary>
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public ProductServices()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Fetches product details by id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public BusinessEntities.ProductEntity GetProductById(int productId)
        {
            var product = _unitOfWork.ProductRepository.GetByID(productId);
            if(product != null)
            {
                Mapper.CreateMap<Product, ProductEntity>();
                var productModel = Mapper.Map<Product, ProductEntity>(product);
                return productModel;
            }
            return null;
        }

        /// <summary>
        /// Fetches all the products.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BusinessEntities.ProductEntity> GetAllProducts()
        {
            var products = _unitOfWork.ProductRepository.GetAll().ToList();

            if(products.Any())
            {
                Mapper.CreateMap<Product, ProductEntity>();
                var productModel = Mapper.Map<List<Product>, List<ProductEntity>>(products);
                return productModel;
            }
            return null;
        }


        /// <summary>
        /// Creates a product
        /// </summary>
        /// <param name="productEntity"></param>
        /// <returns></returns>
        /// For TransactionScope() add using System.Transactions; add reference .Transaction illot allow some of the fields..its only save once we get all datas
        
        public int CreateProduct(BusinessEntities.ProductEntity productEntity)
        {
            using (var scope = new TransactionScope())
            {
                try
                { 
                    var product = new Product
                    {
                        ProductName = productEntity.ProductName
                    };
                    _unitOfWork.ProductRepository.Insert(product);
                    _unitOfWork.save();
                    scope.Complete();
                    return product.ProductId;
                }
                catch (Exception ex)
                {
                    scope.Dispose();          
                    throw;
                }
            }
        }

        /// <summary>
        /// Updates a product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="productEntity"></param>
        /// <returns></returns>
        public bool UpdateProduct(int productId, BusinessEntities.ProductEntity productEntity)
        {
            var success = false;
            if(productEntity != null)
            { 
                using (var scope = new TransactionScope())
                {
                    var product = _unitOfWork.ProductRepository.GetByID(productId);
                    if(product != null)
                    {
                        product.ProductName = productEntity.ProductName;
                        _unitOfWork.ProductRepository.Update(product);
                        _unitOfWork.save();
                        success = true;
                    }
                }
            }
            return success;
        }

        /// <summary>
        /// Deletes a particular product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public bool DeleteProduct(int productID)
        {
            var success = false;
            if(productID > 0)
            {
                using (var scope = new TransactionScope())
                {
                    try
                    {
                        var product = _unitOfWork.ProductRepository.GetByID(productID);
                        if(product != null)
                        {
                            _unitOfWork.ProductRepository.Delete(product);
                            _unitOfWork.save();
                            scope.Complete();
                            success = true;
                        }
                        return success;
                    }
                    catch(Exception ex)
                    {
                        return success;
                        throw;
                    }
                }
            }
            return success;
        }

    }
}
