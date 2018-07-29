using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreData.Entities
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(4), MaxLength(50)]
        public string Name { get; set; }
        [Required, MinLength(4), MaxLength(50)]
        public string Surname { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BornDate { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
