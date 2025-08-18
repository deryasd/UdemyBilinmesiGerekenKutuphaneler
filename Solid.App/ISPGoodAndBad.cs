using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.App.ISPGoodAndBad
{
    //1. Class Library Read Impl
    //2. Class Library Create/Update/Delete

    // 1. Class Library
    public class ReadProductRepository : IProductRepository
    {
        public Product Create(Product product)
        {
            throw new NotImplementedException();
        }

        public Product Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetList()
        {
            throw new NotImplementedException();
        }

        public Product Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
    // 2. Class Library
    public class ReadProductRepository2 : IReadRepository
    {
        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetList()
        {
            throw new NotImplementedException();
        }
    }
    public class WriteProductRepository2 : IWriteRepository
    {
        public Product Create(Product product)
        {
            throw new NotImplementedException();
        }

        public Product Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public Product Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public interface IProductRepository
    {
        List<Product> GetList();
        Product GetById(int id);
        Product Create(Product product);
        Product Update(Product product);
        Product Delete(Product product);
    }

    public interface IReadRepository {
        List<Product> GetList();
        Product GetById(int id);
    }
    public interface IWriteRepository {
        Product Create(Product product);
        Product Update(Product product);
        Product Delete(Product product);
    }


}
