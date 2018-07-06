using System;
using System.Collections.Generic;
using System.Text;

namespace CloudFabric.Library.Common.Entities
{
    public abstract class BaseRoleEntity : BaseEntity
    {
        public string Name { get; set; }

        public List<BaseRolePermissionEntity> RolePermissions { get; set; }
        public List<BaseUserRoleEntity> UserRoles { get; set; }
    }
}
