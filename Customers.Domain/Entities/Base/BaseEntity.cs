﻿namespace Customers.Domain.Entities.Base
{
    public abstract class BaseEntity : IBase
    {
        public BaseEntity()
        {
            DeletedToken = Guid.NewGuid();
        }
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string? DeletedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTimeOffset? DeletedDate { get; set; }
        public Guid? DeletedToken { get; set; }
    }
}
