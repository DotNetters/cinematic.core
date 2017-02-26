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
            if (!page.HasValue)
                page = 1;

            var viewModel = new SessionsIndexViewModel();
            var sessionsPageInfo = SessionManager.GetAll(page.Value, 10);

            viewModel.PageCount = sessionsPageInfo.PageCount;
            viewModel.HasPrevious = page.Value > 1 ? true : false;
            viewModel.HasNext = page.Value < viewModel.PageCount ? true : false;
            viewModel.Sessions = sessionsPageInfo.SessionsPage;
            viewModel.Page = page.Value;

            return View(viewModel);
        }

        // GET: Sessions/Details/5
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            Session session = SessionManager.Get(id.Value);
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
        public IActionResult Create(SessionsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    SessionManager.CreateSession(viewModel.TimeAndDate);
                    DataContext.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (CinematicException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(viewModel);
                }
            }

            return View(viewModel);
        }

        // GET: Sessions/Edit/5
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            Session session = SessionManager.Get(id.Value);
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
        public IActionResult Edit(SessionsEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    SessionManager.UpdateSessionTimeAndDate(viewModel.SessionId, viewModel.TimeAndDate);
                    DataContext.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch(CinematicException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(viewModel);
                }
            }
            return View(viewModel);
        }

        // GET: Sessions/Delete/5
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            Session session = SessionManager.Get(id.Value);
            if (session == null)
            {
                return NotFound();
            }
            return View(session);
        }

        // POST: Sessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (!id.HasValue)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            Session session = SessionManager.Get(id.Value);
            if (session == null)
            {
                return NotFound();
            }
            try
            {
                SessionManager.RemoveSession(id.Value);
                DataContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (CinematicException ex)
            {
                var viewModel = new SessionsDeleteConfirmedViewModel() { Session = session, Exception = ex };
                return View("DeleteConfirmed", viewModel);
            }
        }
    }
}
