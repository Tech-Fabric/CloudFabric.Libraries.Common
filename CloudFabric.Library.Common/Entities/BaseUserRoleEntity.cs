using System;
using System.Collections.Generic;
using System.Text;

namespace CloudFabric.Library.Common.Entities
{
    public abstract class BaseUserRoleEntity<TUser, TRole> : BaseEntity
    {
        public int UserId { get; set; }
        public TUser User { get; set; }

        public int RoleId { get; set; }
        public TRole Roles { get; set; }
    }
}
