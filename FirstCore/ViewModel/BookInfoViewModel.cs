using System.Collections.Generic;
using CoreData.Entities;
using FirstCore.Models;

namespace FirstCore.ViewModel
{
    public class BookInfoViewModel
    {
        public BookInfoViewModel()
        {
            BookHistoryModel = new List<BookHistoryModel>();
        }

        public Book Book { get; set; }
        public Author Author { get; set; }
        public List<BookHistoryModel> BookHistoryModel { get; set; }
    }
}
