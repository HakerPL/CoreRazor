using System;
using System.Collections.Generic;
using CoreData.Entities;

namespace CoreData.Repositories.Interface
{
    public interface IReaderRepository : IRepository<Reader>
    {
        IEnumerable<Reader> GetAllWithBookHistory();
        Reader GetByIdWithBookHistory(int id);
        IEnumerable<Reader> FindWithBookHistory(Func<Reader, bool> predicate);
    }
}
