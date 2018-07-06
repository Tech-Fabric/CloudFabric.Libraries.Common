using System;
using System.Collections.Generic;
using System.Text;

namespace CloudFabric.Library.Common.Entities
{
    public abstract class BaseRolePermissionEntity : BaseEntity
    {
        public int RoleId { get; set; }
        public BaseRoleEntity Role { get; set; }

        public int PermissionId { get; set; }
        public BasePermissionEntity Permission { get; set; }
    }
}
