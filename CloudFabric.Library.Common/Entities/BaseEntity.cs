using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CloudFabric.Library.Common.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual int CreatedBy { get; set; }
        public virtual DateTime LastUpdatedAt { get; set; }
        public virtual int LastUpdatedBy { get; set; }
    }
}
