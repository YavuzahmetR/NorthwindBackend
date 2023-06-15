using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        Product GetById(int productId);
        List<Product> GetByCategoryId(int categoryId);
        List<Product> GetList();
        void Delete(Product product);
        void Add(Product product);
        void Update(Product product);
    }
}
