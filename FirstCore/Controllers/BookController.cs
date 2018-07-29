using CoreData.Entities;
using CoreData.Repositories.Interface;
using FirstCore.Models;
using FirstCore.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FirstCore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _iBookRepository;
        private readonly IAuthorRepository _iAuthorRepository;

        public BookController(IBookRepository iBookRepository, IAuthorRepository iAuthorRepository)
        {
            _iBookRepository = iBookRepository;
            _iAuthorRepository = iAuthorRepository;
        }

        [Route("Book")]
        public IActionResult List()
        {
            if (_iBookRepository.Count(x => true) == 0)
                return View("Empty");

            return View(_iBookRepository.GetAll());
        }

        public IActionResult Delete(int id)
        {
            Book book = _iBookRepository.GetById(id);

            if(book != null)
                _iBookRepository.Delete(book);

            return RedirectToAction("List");
        }

        public IActionResult Create()
        {
            BookCreateViewModel bookCreateViewModel = new BookCreateViewModel()
            {
                Authors = _iAuthorRepository.GetAll()
            };

            return View(bookCreateViewModel);
        }

        [HttpPost]
        public IActionResult Create(BookCreateViewModel bookCreateViewModel)
        {
            if (!ModelState.IsValid)
                return View(bookCreateViewModel);

            _iBookRepository.Create(bookCreateViewModel.Book);

            return RedirectToAction("List");
        }

        public IActionResult Update(int id)
        {
            Book book = _iBookRepository.GetById(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Update(Book book)
        {
            if (!ModelState.IsValid)
                return View(book);

            _iBookRepository.Update(book);

            return RedirectToAction("List");
        }

        public IActionResult Info(int id)
        {
            Book book = _iBookRepository.GetByIdWithBookHistory(id);

            if (book == null)
                return RedirectToAction("List");

            Author author = _iAuthorRepository.GetById(book.AuthorId);

            BookInfoViewModel bookInfoViewModel = new BookInfoViewModel();

            bookInfoViewModel.Book = book;
            bookInfoViewModel.Author = author;

            foreach (BookHistory history in book.BooksHistory)
            {
                BookHistoryModel model = new BookHistoryModel();
                model.ReaderId = history.ReaderId;
                model.ReaderName = history.Reader.Name;
                model.BorrowedDate = history.BorrowedDate;
                model.ReturnDate = history.ReturnDate;

                bookInfoViewModel.BookHistoryModel.Add(model);
            }

            return View(bookInfoViewModel);
        }
    }
}
