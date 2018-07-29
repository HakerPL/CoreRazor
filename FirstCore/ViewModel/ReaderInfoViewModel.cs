using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreData.Entities;
using FirstCore.Models;

namespace FirstCore.ViewModel
{
    public class ReaderInfoViewModel
    {
        public ReaderInfoViewModel()
        {
            BookHistoryModel = new List<BookHistoryModel>();
        }

        public Reader Reader { get; set; }
        public List<BookHistoryModel> BookHistoryModel { get; set; }
    }
}
