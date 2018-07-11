using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudFabric.Library.Common.Attributes
{
    public class CustomAuthorizeAttribute : Attribute
    {
        private List<string> _requiredPermissions;

        public CustomAuthorizeAttribute(List<string> requiredPermissions, IHttpContextAccessor httpContextAccessor = null)
        {
            _requiredPermissions = requiredPermissions;
            Invoke(httpContextAccessor);
        }
        public CustomAuthorizeAttribute(string requiredPermission) : this(new List<string> { requiredPermission })
        {}

        private void Invoke(IHttpContextAccessor httpContextAccessor)
        {
            Console.WriteLine("here i am");
        }
    }
}
