using System;
using System.Collections.Generic;
using System.Text;

namespace CloudFabric.Library.Common.Entities
{
    public abstract class BaseUserEntity<TUserRole> : BaseEntity
    {

        public virtual string Password { get; set; }
        public virtual string EncryptionKey { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual List<TUserRole> UserRoles { get; set; }
    }
}
