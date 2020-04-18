using Data.ApplicationDbContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
  public  class OrdersRepository:IEFRepository<Order>
    {
        

        public void Delete(Order entityToDelete)
        {
            using (ResturanteDbContext _dbContext = new ResturanteDbContext())
            {


            }
        }

        public async Task Delete(object id)
        {
            using (ResturanteDbContext _dbContext = new ResturanteDbContext())
            {
                Order entityToDelete = await _dbContext.Orders.FindAsync(id);
                if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
                {
                    _dbContext.Orders.Attach(entityToDelete);
                }
                _dbContext.Orders.Remove(entityToDelete);
                _dbContext.SaveChanges();
            }

        }



        public IEnumerable<Order> Get(Expression<Func<Order, bool>> filter = null, Func<IQueryable<Order>, IOrderedQueryable<Order>> orderBy = null, string includeProperties = "")
        {
            using (ResturanteDbContext _dbContext = new ResturanteDbContext())
            {
                IQueryable<Order> query = _dbContext.Orders;

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                if (includeProperties != null)
                {
                    foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProperty);
                    }
                }


                if (orderBy != null)
                {

                    return orderBy(query).ToList();
                }
                else
                {
                    try
                    {

                        return query.ToList();
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }

                }
            }


        }

        public async Task<Order> GetByIDAsync(object id)
        {
            using (ResturanteDbContext _dbContext = new ResturanteDbContext())
            {

                return await _dbContext.Orders.Include(a => a.Kind).FirstOrDefaultAsync(a => a.Id == (int)id);
            }
        }

        public IEnumerable<Order> GetWithRawSql(string query, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public void Insert(Order entity)
        {
            using (ResturanteDbContext _dbContext = new ResturanteDbContext())
            {
                _dbContext.Orders.Add(entity);
                _dbContext.SaveChanges();
            }
        }

        public void Update(Order entityToUpdate)
        {
            using (ResturanteDbContext ResturanteDbContext = new ResturanteDbContext())
            {
                var entity = ResturanteDbContext.Orders.FirstOrDefault(a => a.Id == entityToUpdate.Id);
                
                
                ResturanteDbContext.SaveChanges();
            }
        }
    }
}
