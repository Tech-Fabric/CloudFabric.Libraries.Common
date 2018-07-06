using System;
using System.Collections.Generic;
using System.Text;

namespace CloudFabric.Library.Common.Entities
{
    public abstract class BaseRolePermissionEntity<TRole, TPermission> : BaseEntity
    {
        public int RoleId { get; set; }
        public TRole Role { get; set; }

        public int PermissionId { get; set; }
        public TPermission Permission { get; set; }
    }
}
