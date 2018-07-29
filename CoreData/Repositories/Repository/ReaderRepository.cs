using System;
using System.Collections.Generic;
using System.Linq;
using CoreData.Entities;
using CoreData.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoreData.Repositories.Repository
{
    public class ReaderRepository :  Repository<Reader> , IReaderRepository
    {
        public ReaderRepository(LibraryDbContext context) : base(context) { }

        public IEnumerable<Reader> FindWithBookHistory(Func<Reader, bool> predicate)
        {
            return _context.Readers.Include(a => a.BooksHistory).Where(predicate);
        }

        public IEnumerable<Reader> GetAllWithBookHistory()
        {
            return _context.Readers.Include(a => a.BooksHistory);
        }

        public Reader GetByIdWithBookHistory(int id)
        {
            return _context.Readers.Where(b => b.Id == id).Include(a => a.BooksHistory).FirstOrDefault();
        }
    }
}
