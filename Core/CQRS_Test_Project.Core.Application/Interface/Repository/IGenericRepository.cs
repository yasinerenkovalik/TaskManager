using CQRS_Test_Project.Core.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface  IGenericRepository<T> where T : BaseEntity
{
	
    
        Task<List<T>> GetAllAysnc();
        Task<T> GetByIdAsync(Guid Id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(Guid id);
    
}
