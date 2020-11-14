using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WT.Ecommerce.Domain.Models;

namespace WT.Ecommerce.Database.Specifications
{
	public interface ISpecification<T> where T : BaseEntity
	{
		List<Expression<Func<T, bool>>> Criterias { get; }
		List<Expression<Func<T, object>>> Includes { get; }
		List<string> IncludeStrings { get; }
		Expression<Func<T, object>> OrderBy { get; }
		Expression<Func<T, object>> OrderByDescending { get; }
		int Take { get; }
		int Skip { get; }
		bool IsPagingEnabled { get; }
	}
}
