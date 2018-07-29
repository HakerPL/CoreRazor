using System;
using System.Collections.Generic;
using CoreData.Entities;

namespace CoreData.Repositories.Interface
{
    public interface IAuthorRepository : IRepository<Author>
    {
        IEnumerable<Author> GetAllWithBooks();
        Author GetByIdWithBooks(int id);
        IEnumerable<Author> FindWithBooks(Func<Author, bool> predicate);
    }
}
