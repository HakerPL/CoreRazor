using System;
using System.Collections.Generic;
using CoreData.Entities;

namespace CoreData.Repositories.Interface
{
    public interface IBookRepository : IRepository<Book>
    {
        IEnumerable<Book> GetAllWithBookHistory();
        Book GetByIdWithBookHistory(int id);
        IEnumerable<Book> FindWithBookHistory(Func<Book, bool> predicate);
    }
}
