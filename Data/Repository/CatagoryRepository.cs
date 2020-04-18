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
    public  class CatagoryRepository:IEFRepository<Catagory>
    {
        
        public CatagoryRepository()
        {
            
        }

        public void Delete(Catagory entityToDelete)
        {
            using (ResturanteDbContext _dbContext=new ResturanteDbContext())
            {
               

            }
        }

        public async Task Delete(object id)
        {
            using (ResturanteDbContext _dbContext=new ResturanteDbContext())
            {
                Catagory entityToDelete = await _dbContext.Catagories.FindAsync(id);
                if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
                {
                    _dbContext.Catagories.Attach(entityToDelete);
                }
                _dbContext.Catagories.Remove(entityToDelete);
                _dbContext.SaveChanges();
            }
            
        }

      

        public IEnumerable<Catagory> Get(Expression<Func<Catagory, bool>> filter = null, Func<IQueryable<Catagory>, IOrderedQueryable<Catagory>> orderBy = null, string includeProperties = "")
        {
            using (ResturanteDbContext _dbContext = new ResturanteDbContext())
            {
                IQueryable<Catagory> query =_dbContext.Catagories;

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

        public async Task<Catagory> GetByIDAsync(object id)
        {
            using (ResturanteDbContext _dbContext=new ResturanteDbContext())
            {

                return await _dbContext.Catagories.Include(a=>a.Kinds).FirstOrDefaultAsync(a=>a.Id==(int)id);
            }
        }

        public IEnumerable<Catagory> GetWithRawSql(string query, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public void Insert(Catagory entity)
        {
            using (ResturanteDbContext _dbContext=new ResturanteDbContext())
            {
               _dbContext.Catagories.Add(entity);
                _dbContext.SaveChanges();
            }
        }

        public void Update(Catagory entityToUpdate)
        {
            using (ResturanteDbContext ResturanteDbContext=new ResturanteDbContext())
            {
              var entity= ResturanteDbContext.Catagories.FirstOrDefault(a=>a.Id==entityToUpdate.Id);
                entity.ImagePath = entityToUpdate.ImagePath;
                entity.Name = entityToUpdate.Name;
                ResturanteDbContext.SaveChanges();
            }
        }
    }
}
