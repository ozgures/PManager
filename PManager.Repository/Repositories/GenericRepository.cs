using Microsoft.EntityFrameworkCore;
using PManager.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PManager.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {


        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        //    public async  Task AddAsync(T entity)
        //    {
        //        await _dbSet.AddAsync(entity);
        //    }

        //    public async Task AddRangeAsync(IEnumerable<T> entities)
        //    {
        //        await _dbSet.AddRangeAsync(entities);
        //    }

        //    public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        //    {
        //        return await _dbSet.AnyAsync(expression);
        //    }

        //    public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
        //    {
        //        return _dbSet.AsNoTracking().AsQueryable();
        //        //burada asNoTracking dememimizn sebebi. EF core çekmiş olduğu dataları
        //        //memoriye almasın track etmesin ki daha performanslı çalıssın,
        //        //eğer 1000 data çekeceksek ve asnoTrackin dersek 1000 datayı memorye çeker ve track ederek izler
        //        //buda performasnın düşmesine sebep olur, bu 1000 kayıt dispose edene kadar memoride bekler
        //    }

        //    public async Task<T> GetByIdAsync(int id)
        //    {
        //        return await _dbSet.FindAsync(id);
        //    }

        //    public void Remove(T entity)
        //    {
        //        //_context.Entry(entity).State = EntityState.Deleted;
        //        //buarada asenkron olmamasının sebebi entity üzerinde sadece ilgili kolonlara enum atıyor,
        //        //ağır bir yük yok bu yüzden asenron yapmıyoruz
        //        _dbSet.Remove(entity);


        //    }

        //    public void RemoveRange(IEnumerable<T> entities)
        //    {
        //        _dbSet.RemoveRange(entities);
        //    }

        //    public void Update(T entity)
        //    {
        //        _dbSet.Update(entity);
        //    }

        //    public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        //    {
        //        return _dbSet.Where(expression);
        //    }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        public IQueryable<T> GetAll()
        {
            //Tracking özelliğini kapatıyoruz çünkü GetAll daha performanslı çalışması için. Read operasyonu olacağı için server tabanlı bir kayıt işlemi olmadığı için tracking özelliğini kapatıyoruz.Update-Insert-Delete yapmayacağız sadece datayı çekiyoruz.
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            //Primary key bekler.
            return await _dbSet.FindAsync(id);
        }

        //Track edilen entity'nin State'ini delete eder. Yorum satırında yazılan ile Remove aynı işlemi yapar aslında. O sebeple Asenkron olmasına performans açısından gerek yoktur. 
        public void Remove(T entity)
        {
            //_context.Entry(entity).State = EntityState.Deleted;
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            //_context.Entry(entity).State = EntityState.Modified;
            _dbSet.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}
