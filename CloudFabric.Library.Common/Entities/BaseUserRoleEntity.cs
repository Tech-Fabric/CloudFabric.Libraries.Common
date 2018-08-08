using System;
using System.Collections.Generic;
using System.Text;

namespace CloudFabric.Library.Common.Entities
{
    public abstract class BaseUserRoleEntity<TUser, TRole> : BaseEntity
    {
        public virtual int UserId { get; set; }
        public virtual TUser User { get; set; }

        public virtual int RoleId { get; set; }
        public virtual TRole Role { get; set; }
    }
}
