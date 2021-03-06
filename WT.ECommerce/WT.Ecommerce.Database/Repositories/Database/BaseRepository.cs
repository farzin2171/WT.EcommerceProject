﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WT.Ecommerce.Database.Repositories.Interfaces;
using WT.Ecommerce.Database.Specifications;
using WT.Ecommerce.Domain.Models;

namespace WT.Ecommerce.Database.Repositories.Database
{
	public abstract class BaseRepository<T> : IDatabaseRepository<T> where T : BaseEntity
    {
		protected readonly ApplicationDbContext _dbContext;

		public BaseRepository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public virtual async Task<T> GetByIdAsync(int id)
		{
			return await _dbContext.Set<T>().FindAsync(id);
		}

		public async Task<IReadOnlyList<T>> ListAllAsync()
		{
			return await _dbContext.Set<T>().ToListAsync();
		}

		public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
		{
			return await ApplySpecification(spec).ToListAsync();
		}

		public async Task<int> CountAsync(ISpecification<T> spec)
		{
			return await ApplySpecification(spec).CountAsync();
		}

		public async Task<T> AddAsync(T entity)
		{
			_dbContext.Set<T>().Add(entity);
			await _dbContext.SaveChangesAsync();

			return entity;
		}

		public async Task UpdateAsync(T entity)
		{
			_dbContext.Entry(entity).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
		}

		public async Task DeleteAsync(T entity)
		{
			_dbContext.Set<T>().Remove(entity);
			await _dbContext.SaveChangesAsync();
		}

		private IQueryable<T> ApplySpecification(ISpecification<T> spec)
		{
			return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
		}

		//public async Task BulkMergeAsync(IEnumerable<T> entities)
		//{
		//	await _dbContext.BulkMergeAsync(entities);
		//}

		//public async Task BulkDeleteAsync(IEnumerable<T> entities)
		//{
		//	await _dbContext.(entities);
		//}
	}
}
