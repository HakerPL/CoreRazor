using System;
using System.Data;
using CoreData.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreData
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookHistory> BooksHistory { get; set; }
        public DbSet<Reader> Readers { get; set; }
    }
}
