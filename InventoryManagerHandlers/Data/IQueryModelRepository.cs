using _365Solutions.Shared.Contracts;
using InventoryManager.Model.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Query.Handlers.Data
{
   public interface IQueryModelRepository<T, TId> where T : IQueryModel

    {
        Task<T> LoadModelAsync(TId modelId);
        Task<IEnumerable<T>> FindModelAsync(List<SearchParameter> searchParameters);
        Task<TId> SaveModelAsync(T model);
    }
}
