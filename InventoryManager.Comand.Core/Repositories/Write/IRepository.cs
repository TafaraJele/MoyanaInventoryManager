using _365Solutions.Shared.Contracts;
using _365Solutions.Shared.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Comand.Core.Repositories.Write
{
    public interface IRepository<T, TId> where T : IAggregateRoot
    {
        Task<IEnumerable<T>> FindAggregatesAsync(List<SearchParameter> searchParameters, FilterType filterType);
        Task<T> LoadAggregateAsync(TId id);
        Task<TId> SaveAggregateAsync(T aggregate);
    }
}
