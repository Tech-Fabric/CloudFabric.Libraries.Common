using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CloudFabric.Library.Common.Entities
{
    public abstract class BasePermissionEntity<TRole, TRolePermission> : BaseEntity
    {
        public string Value { get; set; }

        
        //public TRole RoleId { get; set; }
        public List<TRolePermission> RolePermissions { get; set; }
    }
}
