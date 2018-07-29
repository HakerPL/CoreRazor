using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreData.Entities;
using CoreData.Repositories.Interface;
using FirstCore.Models;
using FirstCore.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FirstCore.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _iAuthorRepository;
        private readonly IBookRepository _iBookRepository;

        public AuthorController(IAuthorRepository iAuthorRepository, IBookRepository iBookRepository)
        {
            _iAuthorRepository = iAuthorRepository;
            _iBookRepository = iBookRepository;
        }

        [Route("Author")]
        public IActionResult List()
        {
            if (_iAuthorRepository.Count(x => true) == 0)
                return View("Empty");

            return View(_iAuthorRepository.GetAll());
        }

        public IActionResult Delete(int id)
        {
            Author author = _iAuthorRepository.GetById(id);

            if (author != null)
                _iAuthorRepository.Delete(author);

            return RedirectToAction("List");
        }

        public IActionResult Create()
        {
            var viewModel = new AuthorCreateViewModel
            {
                Author = new Author(),
                BackToAction = Request.Headers["Referer"].ToString()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(AuthorCreateViewModel authorCreateViewModel)
        {
            if (!ModelState.IsValid)
                return View(authorCreateViewModel);

            _iAuthorRepository.Create(authorCreateViewModel.Author);

            return RedirectToAction("List");
        }

        public IActionResult Update(int id)
        {
            Author author = _iAuthorRepository.GetById(id);
            return View(author);
        }

        [HttpPost]
        public IActionResult Update(Author author)
        {
            if (!ModelState.IsValid)
                return View(author);

            _iAuthorRepository.Update(author);

            return RedirectToAction("List");
        }

        public IActionResult Info(int id)
        {
            Author author = _iAuthorRepository.GetByIdWithBooks(id);

            if (author == null)
                return RedirectToAction("List");

            return View(author);
        }
    }
}
