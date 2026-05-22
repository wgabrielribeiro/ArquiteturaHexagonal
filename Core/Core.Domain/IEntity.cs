using System;

namespace Core.Domain
{
    internal interface IEntity
    {
        Guid Id { get; }
    }
}
