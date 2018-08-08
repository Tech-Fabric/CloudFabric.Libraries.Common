using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CloudFabric.Library.Common.Entities
{
    public abstract class BasePermissionEntity<TRole, TRolePermission> : BaseEntity
    {
        public virtual string Value { get; set; }

        
        //public TRole RoleId { get; set; }
        public virtual List<TRolePermission> RolePermissions { get; set; }
    }
}
