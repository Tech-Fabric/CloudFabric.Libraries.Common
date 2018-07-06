using System;
using System.Collections.Generic;
using System.Text;

namespace CloudFabric.Library.Common.Entities
{
    public abstract class BasePermissionEntity : BaseEntity
    {
        public string Value { get; set; }
        public BaseRoleEntity RoleId { get; set; }

        public List<BaseRolePermissionEntity> RolePermissions { get; set; }
    }
}
