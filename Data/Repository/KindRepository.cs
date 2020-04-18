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
   public class KindRepository:IEFRepository<Kind>
    {
        public void Delete(Kind entityToDelete)
        {
           
        }

        public async Task Delete(object id)
        {
            using (ResturanteDbContext _dbContext = new ResturanteDbContext())
            {
                Kind entityToDelete = await _dbContext.Kinds.FindAsync(id);
                if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
                {
                    _dbContext.Kinds.Attach(entityToDelete);
                }
                _dbContext.Kinds.Remove(entityToDelete);
                _dbContext.SaveChanges();
            }

        }



        public IEnumerable<Kind> Get(Expression<Func<Kind, bool>> filter = null, Func<IQueryable<Kind>, IOrderedQueryable<Kind>> orderBy = null, string includeProperties = "")
        {
            using (ResturanteDbContext _dbContext = new ResturanteDbContext())
            {
                IQueryable<Kind> query = _dbContext.Kinds;

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

        public async Task<Kind> GetByIDAsync(object id)
        {
            using (ResturanteDbContext _dbContext = new ResturanteDbContext())
            {
                return await _dbContext.Kinds.FindAsync(id);
            }
        }

        public IEnumerable<Kind> GetWithRawSql(string query, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public void Insert(Kind entity)
        {
            using (ResturanteDbContext _dbContext = new ResturanteDbContext())
            {
                _dbContext.Kinds.Add(entity);
                try
                {
                     _dbContext.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw;
                }
              
            }
        }

        public void Update(Kind entityToUpdate)
        {
            using (ResturanteDbContext ResturanteDbContext = new ResturanteDbContext())
            {
                var entity = ResturanteDbContext.Kinds.FirstOrDefault(a => a.Id == entityToUpdate.Id);
                entity.ImagePath = entityToUpdate.ImagePath;
                entity.Name = entityToUpdate.Name;
                entity.Price = entityToUpdate.Price;
                entity.CatagoryId = entityToUpdate.CatagoryId;
                ResturanteDbContext.SaveChanges();
            }
        }
    }
}
