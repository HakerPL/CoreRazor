using System;
using System.Collections.Generic;
using System.Linq;
using CoreData.Entities;
using CoreData.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoreData.Repositories.Repository
{
    public class AuthorRepository : Repository<Author> , IAuthorRepository
    {
        public AuthorRepository(LibraryDbContext context) : base(context) { }

        public IEnumerable<Author> FindWithBooks(Func<Author, bool> predicate)
        {
            return _context.Authors.Include(a => a.Books).Where(predicate);
        }

        public IEnumerable<Author> GetAllWithBooks()
        {
            return _context.Authors.Include(a => a.Books);
        }

        public Author GetByIdWithBooks(int id)
        {
            return _context.Authors.Where(b => b.Id == id).Include(a => a.Books).FirstOrDefault();
        }
    }
}
