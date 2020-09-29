using _365Solutions.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagerQueryAPI.Helpers
{
    public static class SecurityContextHelper
    {
        public static RequestContext GetCurrentRequestContext()
        {
            RequestContext context =
                new RequestContext(Guid.NewGuid(), Guid.Parse("7c9e6679-7425-40de-944b-e07fc1f90ae7"), Guid.Parse("7d9e6679-7425-40de-944b-e07fc1f90ae7"))
                {
                    UserEmail = "test@gmail.com"
                };
            return context;
        }
    }
}
