using System;
using System.Collections.Generic;
using System.Text;
using CoreData.Entities;
using CoreData.Repositories.Interface;
using System.Linq;

namespace CoreData.Repositories.Repository
{
    public class BookHistoryRepository : Repository<BookHistory> , IBookHistoryRepository
    {
        public BookHistoryRepository(LibraryDbContext context) : base(context) { }

        public BookHistory GetLastRecord(int bookId)
        {
            return _context.BooksHistory.OrderByDescending(u => u.BookId == bookId).FirstOrDefault();
        }
    }
}
