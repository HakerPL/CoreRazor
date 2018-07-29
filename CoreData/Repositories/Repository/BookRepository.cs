using System;
using System.Collections.Generic;
using System.Linq;
using CoreData.Entities;
using CoreData.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoreData.Repositories.Repository
{
    public class BookRepository : Repository<Book> , IBookRepository
    {
        public BookRepository(LibraryDbContext context) : base(context) { }

        public IEnumerable<Book> FindWithBookHistory(Func<Book, bool> predicate)
        {
            return _context.Books.Include(a => a.BooksHistory).Where(predicate);
        }

        public IEnumerable<Book> GetAllWithBookHistory()
        {
            return _context.Books.Include(a => a.BooksHistory);
        }

        public Book GetByIdWithBookHistory(int id)
        {
            return _context.Books.Where(b => b.Id == id).Include(a => a.BooksHistory).FirstOrDefault();
        }
    }
}
