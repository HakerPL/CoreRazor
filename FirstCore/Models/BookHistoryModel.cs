using System;

namespace FirstCore.Models
{
    public class BookHistoryModel
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public int ReaderId { get; set; }
        public string ReaderName { get; set; }
        public DateTime BorrowedDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
