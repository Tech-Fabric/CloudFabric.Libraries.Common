using System;
using System.Collections.Generic;
using System.Text;

namespace CloudFabric.Library.Common.Entities
{
    public abstract class BaseRolePermissionEntity<TRole, TPermission> : BaseEntity
    {
        public virtual int RoleId { get; set; }
        public virtual TRole Role { get; set; }

        public virtual int PermissionId { get; set; }
        public virtual TPermission Permission { get; set; }
    }
}
