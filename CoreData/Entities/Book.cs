using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoreData.Entities
{
    public enum BookType
    {
        SciFi,
        Comedy,
        Horror,
        Action,
        Poetry
    }

    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(4), MaxLength(100)]
        public string Title { get; set; }
        [Required, MinLength(4), MaxLength(50)]
        public string Isbn { get; set; }
        public BookType BookType { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        public bool Borrowed { get; set; } = false;

        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public virtual ICollection<BookHistory> BooksHistory { get; set; }
    }
}
