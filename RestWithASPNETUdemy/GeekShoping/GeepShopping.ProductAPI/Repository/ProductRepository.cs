using AutoMapper;
using GeepShopping.ProductAPI.Data.ValueObjects;
using GeepShopping.ProductAPI.Model;
using GeepShopping.ProductAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeepShopping.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private IProductContext _dbContext;
        private IMapper _mapper;

        public ProductRepository(IProductContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProductVO> Create(ProductVO dto)
        {
            var product = _mapper.Map<Product>(dto);
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                var products = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
                if(products == null)
                    return false;
                _dbContext.Products.Remove(products);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<IEnumerable<ProductVO>> FindAll()
        {
            var products = await _dbContext.Products.ToListAsync();
            return _mapper.Map<List<ProductVO>>(products);
        }

        public async Task<ProductVO> FindById(long id)
        {
            var products = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            return _mapper.Map<ProductVO>(products);
        }

        public async Task<ProductVO> Update(ProductVO dto)
        {
            var product = _mapper.Map<Product>(dto);
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<ProductVO>(product);
        }
    }
}
