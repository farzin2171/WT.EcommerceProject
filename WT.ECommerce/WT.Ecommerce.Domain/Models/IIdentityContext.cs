using System.Collections.Generic;
using System.Security.Claims;

namespace WT.Ecommerce.Domain.Models
{
	/// <summary>
	/// Represents the identity in context.
	/// </summary>
	public interface IIdentityContext
    {
		/// <summary>
		/// Gets the identifier of the Principal
		/// </summary>
		string UserCode { get; }

		string UserFullName { get; }

		/// <summary>
		/// Gets the collection of <see cref="Claim"/> associated with the Principal
		/// </summary>
		IEnumerable<Claim> Claims { get; }
	}
}
