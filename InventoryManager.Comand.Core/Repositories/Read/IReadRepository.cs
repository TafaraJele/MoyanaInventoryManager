using _365Solutions.Shared.Contracts;
using InventoryManager.Model.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Comand.Core.Repositories
{
    public interface IReadRepository<T,TId> where T : IQueryModel
    {
        Task<IEnumerable<T>> FindModelAsync(List<SearchParameter> searchParameters);
        Task<T> LoadModelAsync(TId id);
        Task<TId> SaveModelAsync(T model);
    }
}
