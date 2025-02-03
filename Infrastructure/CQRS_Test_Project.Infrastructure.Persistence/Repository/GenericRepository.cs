using CQRS_Test_Project.Core.Domain.Entities.Base;
using CQRS_Test_Project.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Test_Project.Infrastructure.Persistence.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly CqrsContext _appContext;
        public GenericRepository(CqrsContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _appContext.Set<T>().AddAsync(entity);
            await _appContext.SaveChangesAsync();
     
            return entity;
        }

        public async Task<T> DeleteAsync(Guid id)
        {

            var entity = await _appContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception("Kayıt bulunamadı.");
            }

            _appContext.Set<T>().Remove(entity); 
            await _appContext.SaveChangesAsync();

            return entity;
        }



        public async Task<List<T>> GetAllAysnc()
        {

            return await _appContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid Id)
        {
            return await _appContext.Set<T>().FirstOrDefaultAsync(x => x.Id == Id );
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _appContext.Set<T>().Update(entity);
            await _appContext.SaveChangesAsync();

            return entity;
        }
    }
}
