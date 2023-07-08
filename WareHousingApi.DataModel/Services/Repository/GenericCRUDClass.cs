using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WareHousingApi.DataModel.Services.Repository
{
    public class GenericCRUDClass<Tentity> where Tentity : class
    {
        private readonly ApplicationDbContext _context;
        private DbSet<Tentity> _table;

        public GenericCRUDClass(ApplicationDbContext context)
        {
            _context = context;
            _table = context.Set<Tentity>();
        }

        public virtual void Create(Tentity entity)
        {
            _table.Add(entity);
        }

        public async void CreateAsync(Tentity entity, CancellationToken cancellationToken)
        {
            await _table.AddAsync(entity, cancellationToken).ConfigureAwait(false);
        }

        public virtual void Update(Tentity entity)
        {
            _table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual IEnumerable<Tentity> Get(Expression<Func<Tentity, bool>> whereVariable = null, string JoinStrig = "")
        {
            IQueryable<Tentity> query = _table;

            if (whereVariable != null)
            {
                query = query.Where(whereVariable);
            }

            if (JoinStrig != "")
            {
                foreach (string item in JoinStrig.Split(','))
                {
                   query = query.Include(item);
                }
            }

            return query;
        }

        public virtual Tentity GetById(object id)
        {
            return _table.Find(id);
        }

        public virtual void Delete(Tentity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _table.Attach(entity);
            }
            _table.Remove(entity);
        }

        public virtual void DeleteById(object id)
        {
            var entity = GetById(id);
            Delete(entity);
        }

        public virtual void DeleteByRange(IEnumerable<Tentity> entities) => _table.RemoveRange(entities);
        
        
    }
}