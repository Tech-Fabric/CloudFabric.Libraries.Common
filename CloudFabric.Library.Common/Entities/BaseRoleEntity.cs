using System;
using System.Collections.Generic;
using System.Text;

namespace CloudFabric.Library.Common.Entities
{
    public abstract class BaseRoleEntity<TUserRole, TRolePermission> : BaseEntity
    {
        public string Name { get; set; }

        public List<TRolePermission> RolePermissions { get; set; }
        public List<TUserRole> UserRoles { get; set; }
    }
}
