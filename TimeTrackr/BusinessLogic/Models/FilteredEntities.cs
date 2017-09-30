using System.Collections.Generic;

namespace BusinessLogic.Models
{
    public class FilteredEntities<T>
        where T : class, new()
    {
        public IList<T> Entities;
        public int TotalNumber;
    }
}
