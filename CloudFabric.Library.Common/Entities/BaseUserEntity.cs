using System;
using System.Collections.Generic;
using System.Text;

namespace CloudFabric.Library.Common.Entities
{
    public abstract class BaseUserEntity : BaseEntity
    {
        public List<BaseUserRoleEntity> UserRoles { get; set; }
    }
}
