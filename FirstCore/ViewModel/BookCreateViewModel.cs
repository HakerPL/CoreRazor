using System.Collections.Generic;
using CoreData.Entities;

namespace FirstCore.ViewModel
{
    public class BookCreateViewModel
    {
        public Book Book { get; set; }
        public IEnumerable<Author> Authors { get; set; }
    }
}
