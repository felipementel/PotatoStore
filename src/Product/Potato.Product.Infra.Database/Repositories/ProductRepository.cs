﻿using Potato.Product.Domain.Repositories;

namespace Potato.Product.Infra.Database.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public void Add(Domain.Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Domain.Product GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Domain.Product product)
        {
            throw new NotImplementedException();
        }
    }
}