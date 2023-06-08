using SocioFormador.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocioFormador.Domain.Common.Abstractions;

public abstract class EntityBase<TKey, TUserKey> : IEntityBase<TKey, TUserKey>
{
    public TKey Id { get ; set ; }
    public TUserKey CreatedBy { get; set; } 
    public DateTime CreatedAt { get ; set ; }
}
