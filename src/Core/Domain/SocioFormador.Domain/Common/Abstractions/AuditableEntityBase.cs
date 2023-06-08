
using SocioFormador.Domain.Common.Interfaces;

namespace SocioFormador.Domain.Common.Abstractions;

public abstract class AuditableEntityBase<TKey, TUserKey> : EntityBase<TKey, TUserKey>, IAuditableEntityBase<TKey, TUserKey>
{
    public TUserKey UpdatedBy { get ; set ; }
    public DateTime UpdatedAt { get ; set ; }
}
