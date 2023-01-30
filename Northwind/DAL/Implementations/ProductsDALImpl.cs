using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class ProductsDALImpl : IProductsDAL
    {
        NorthWindContext context;


        public ProductsDALImpl()
        {
            context = new NorthWindContext();

        }

        public ProductsDALImpl(NorthWindContext _Context)
        {
            context = _Context;

        }

        public bool Add(Product entity)
        {
            try
            {
                using (UnidadDeTrabajo<Product> unidad = new UnidadDeTrabajo<Product>(context))
                {
                    unidad.genericDAL.Add(entity);
                    unidad.Complete();
                }


                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void AddRange(IEnumerable<Product> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> Find(Expression<Func<Product, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            Product products;
            using (UnidadDeTrabajo<Product> unidad = new UnidadDeTrabajo<Product>(context))
            {

                products = unidad.genericDAL.Get(id);
            }
            return products;
        }

        public IEnumerable<Product> GetAll()
        {
            try
            {
                IEnumerable<Product> products;
                using (UnidadDeTrabajo<Product> unidad = new UnidadDeTrabajo<Product>(context))
                {
                    products = unidad.genericDAL.GetAll();
                }
                return products;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Product entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Product> unidad = new UnidadDeTrabajo<Product>(context))
                {
                    unidad.genericDAL.Remove(entity);
                    result = unidad.Complete();
                }
            }
            catch (Exception)
            {

                result = false;
            }

            return result;
        
    }

        public void RemoveRange(IEnumerable<Product> entities)
        {
            throw new NotImplementedException();
        }

        public Product SingleOrDefault(Expression<Func<Product, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Product entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Product> unidad = new UnidadDeTrabajo<Product>(context))
                {
                    unidad.genericDAL.Update(entity);
                    result = unidad.Complete();
                }

            }
            catch (Exception)
            {

                return false;
            }

            return result;
        }
    }
    
}
