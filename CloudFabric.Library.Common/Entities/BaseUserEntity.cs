using System;
using System.Collections.Generic;
using System.Text;

namespace CloudFabric.Library.Common.Entities
{
    public abstract class BaseUserEntity<TUserRole> : BaseEntity
    {

        public string Password { get; set; }
        public string EncryptionKey { get; set; }
        public bool IsActive { get; set; }
        public List<TUserRole> UserRoles { get; set; }
    }
}
