using System.Collections.Generic;
using System.Security.Claims;

namespace WT.Ecommerce.Domain.Models
{
    public class IdentityContext : IIdentityContext
    {
        private readonly ClaimsPrincipal _principal;
        public IdentityContext(ClaimsPrincipal principal)
        {
            _principal = principal;
        }
        public string UserCode => _principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        public string UserFullName
        {
            get
            {
                var firstName = _principal.FindFirst(c => c.Type == ClaimTypes.GivenName).Value;
                var lastName = _principal.FindFirst(c => c.Type == ClaimTypes.Surname).Value;

                return $"{firstName} {lastName}";
            }
        }

        public IEnumerable<Claim> Claims => _principal.Claims;

        public override string ToString()
        {
            return $"{_principal.Identity.Name} - UserCode:{UserCode}";
        }
    }
}
