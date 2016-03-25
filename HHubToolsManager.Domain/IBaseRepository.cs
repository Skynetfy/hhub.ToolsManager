using System;
using HHubToolsManager.Domain.Entities;

namespace HHubToolsManager.Domain
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        T Add(T entity);
    }
}
