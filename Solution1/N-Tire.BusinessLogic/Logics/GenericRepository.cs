using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using N_Tier.Data.DAL;
using N_Tire.BusinessLogic.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace N_Tire.BusinessLogic.Logics
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MyDataBaseDbContext _dataBase;
        public GenericRepository(MyDataBaseDbContext dataBase)
        {
            _dataBase = dataBase;
        }
        public DbSet<T> Table =>  _dataBase.Set<T>();
        public async Task Add(T entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task AddAndCommit(T entity)
        {
            await Add(entity);
            await Commit();
        }

        public async Task Commit()
        {
            await _dataBase.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            Table.Remove(entity);
        }

        public async Task<List<T>> GetAll()
        {
            return await Table.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {

            return await Table.FindAsync(id);
        }

        public async Task<List<T>> GetTableByExpresion(Expression<Func<T, bool>> expression)
        {
            return await Table.Where(expression).ToListAsync();
        }

        public void Update(T entity)
        {
            Table.Update(entity);
        }
    }
}
