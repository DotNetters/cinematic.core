using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Cinematic.Contracts;
using Cinematic.Web.Models.SessionViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Cinematic.Web.Controllers
{
    public class SessionsController : Controller
    {
        IDataContext DataContext { get; set; } = null;

        ISessionManager SessionManager { get; set; } = null;

        public SessionsController(IDataContext dataContext, ISessionManager sessionManager)
        {
            if (dataContext == null)
                throw new ArgumentNullException("dataContext");
            if (sessionManager == null)
                throw new ArgumentNullException("sessionManager");

            DataContext = dataContext;
            SessionManager = sessionManager;
        }

        // GET: Sessions
        public IActionResult Index(int? page)
        {
            var viewModel = new SessionsIndexViewModel();
            viewModel.PageCount = Math.Ceiling((double)DataContext.Sessions.Count() / 10);

            if (page.HasValue)
            {
                viewModel.HasPrevious = page.Value > 1 ? true : false;
                viewModel.HasNext = page.Value < viewModel.PageCount ? true : false;
                viewModel.Sessions = DataContext.Sessions.Skip((page.Value - 1) * 10).Take(10);
                viewModel.Page = page.Value;
            }
            else
            {
                viewModel.HasPrevious = false;
                viewModel.HasNext = viewModel.PageCount > 1 ? true : false;
                viewModel.Sessions = DataContext.Sessions.Skip(0).Take(10);
                viewModel.Page = 1;
            }

            return View(viewModel);

        }

        // GET: Sessions/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            Session session = DataContext.Find<Session>(id);
            if (session == null)
            {
                return NotFound();
            }
            return View(session);
        }

        // GET: Sessions/Create
        public ActionResult Create()
        {
            var viewModel = new SessionsViewModel();
            return View(viewModel);
        }

        // POST: Sessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SessionsViewModel session)
        {
            if (ModelState.IsValid)
            {
                SessionManager.CreateSession(session.TimeAndDate);
                DataContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(session);
        }

        // GET: Sessions/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            Session session = DataContext.Find<Session>(id);
            if (session == null)
            {
                return NotFound();
            }

            var viewModel = new SessionsEditViewModel(session);

            return View(viewModel);
        }

        // POST: Sessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,TimeAndDate,Status")] Session session)
        {
            if (ModelState.IsValid)
            {
                DataContext.Update(session);
                DataContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(session);
        }

        // GET: Sessions/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            Session session = DataContext.Find<Session>(id);
            if (session == null)
            {
                return NotFound();
            }
            return View(session);
        }

        // POST: Sessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Session session = DataContext.Find<Session>(id);            
            if (session == null)
            {
                return NotFound();
            }
            try
            {
                SessionManager.RemoveSession(session);
                DataContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (CinematicException ex)
            {
                var viewModel = new SessionsDeleteConfirmedViewModel() { Session = session, Exception = ex };
                return View("DeleteConfirmed", viewModel);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DataContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
