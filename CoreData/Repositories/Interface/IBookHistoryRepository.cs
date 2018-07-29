using CoreData.Entities;

namespace CoreData.Repositories.Interface
{
    public interface IBookHistoryRepository : IRepository<BookHistory>
    {
        BookHistory GetLastRecord(int bookId);
    }
}
