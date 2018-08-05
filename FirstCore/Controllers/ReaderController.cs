using CoreData.Entities;
using CoreData.Repositories.Interface;
using FirstCore.Models;
using FirstCore.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FirstCore.Controllers
{
    public class ReaderController : Controller
    {
        private readonly IReaderRepository _readerRepository;

        public ReaderController(IReaderRepository readerRepository)
        {
            _readerRepository = readerRepository;
        }

        [Route("Reader")]
        public IActionResult List()
        {
            if (_readerRepository.Count(x => true) == 0)
                return View("Empty");

            return View(_readerRepository.GetAll());
        }

        public IActionResult Delete(int id)
        {
            Reader reader = _readerRepository.GetById(id);

            if(reader != null)
                _readerRepository.Delete(reader);

            return RedirectToAction("List");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Reader reader)
        {
            if (!ModelState.IsValid)
                return View(reader);

            _readerRepository.Create(reader);

            return RedirectToAction("List");
        }

        public IActionResult Update(int id)
        {
            Reader reader = _readerRepository.GetById(id);

            return View(reader);
        }

        [HttpPost]
        public IActionResult Update(Reader reader)
        {
            if (!ModelState.IsValid)
                return View(reader);

            _readerRepository.Update(reader);

            return RedirectToAction("List");
        }

        public IActionResult Info(int id)
        {
            Reader reader = _readerRepository.GetByIdWithBookHistory(id);

            if (reader == null)
                return RedirectToAction("List");

            ReaderInfoViewModel readerInfoViewModel = new ReaderInfoViewModel();

            readerInfoViewModel.Reader = reader;

            foreach (BookHistory history in reader.BooksHistory)
            {
                BookHistoryModel model = new BookHistoryModel();
                model.BookId = history.BookId;
                model.BookTitle = history.Book.Title;
                model.BorrowedDate = history.BorrowedDate;
                model.ReturnDate = history.ReturnDate;

                readerInfoViewModel.BookHistoryModel.Add(model);
            }

            return View(readerInfoViewModel);
        }
    }
}
