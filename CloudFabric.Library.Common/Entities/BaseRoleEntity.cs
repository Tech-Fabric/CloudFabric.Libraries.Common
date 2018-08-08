using System;
using System.Collections.Generic;
using System.Text;

namespace CloudFabric.Library.Common.Entities
{
    public abstract class BaseRoleEntity<TUserRole, TRolePermission> : BaseEntity
    {
        public virtual string Name { get; set; }

        public virtual List<TRolePermission> RolePermissions { get; set; }
        public virtual List<TUserRole> UserRoles { get; set; }
    }
}
