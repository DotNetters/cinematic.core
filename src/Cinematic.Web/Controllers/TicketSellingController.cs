﻿using System;
using System.Collections.Generic;
using System.Linq;
using Cinematic.Contracts;
using Cinematic.Resources;
using Microsoft.AspNetCore.Mvc;
using Cinematic.Web.Models.TicketSellingViewModels;

namespace Cinematic.Web.Controllers
{
    public class TicketSellingController : Controller
    {
        ISessionManager SessionManager = null;
        ISeatManager SeatManager = null;
        ITicketManager TicketManager = null;
        IDataContext DataContext = null;

        public TicketSellingController(
            ISessionManager sessionManager,
            ISeatManager seatManager,
            ITicketManager ticketManager,
            IDataContext dataContext)
        {
            if (sessionManager == null)
                throw new ArgumentNullException("sessionManager");
            if (seatManager == null)
                throw new ArgumentNullException("seatManager");
            if (ticketManager == null)
                throw new ArgumentNullException("ticketManager");
            if (dataContext == null)
                throw new ArgumentNullException("dataContext");

            SessionManager = sessionManager;
            SeatManager = seatManager;
            TicketManager = ticketManager;
            DataContext = dataContext;
        }

        // GET: TicketSelling
        public ActionResult Index(int? id)
        {
            var viewModel = new TicketSellingIndexViewModel();
            var availableSessions = SessionManager.GetAvailableSessions();

            if (availableSessions.Count() > 0)
            {
                viewModel.AvailableSessions = availableSessions;
                if (id.HasValue)
                {
                    var selectedSession = availableSessions.Where(s => s.Id == id).FirstOrDefault();
                    if (selectedSession != null)
                    {
                        viewModel.SelectedSession = selectedSession;
                    }
                    else
                    {
                        return NotFound(Messages.SessionNotAvailableOrNotFound);
                    }
                }
                else
                {
                    viewModel.SelectedSession = viewModel.AvailableSessions.First();
                }
            }

            if (viewModel.SelectedSession != null)
            {
                viewModel.AvailableSeats = SeatManager.GetAvailableSeats(viewModel.SelectedSession);
            }

            return View(viewModel);
        }

        public ActionResult TicketsSold(int? id, string selectedSeats)
        {
            var viewModel = new TicketsSoldViewModel();

            try
            {
                if (!string.IsNullOrWhiteSpace(selectedSeats))
                {
                    var session = SessionManager.GetAvailableSessions().Where(s => s.Id == id).FirstOrDefault();

                    var seatLocators = GetSeatLocators(selectedSeats);

                    foreach (var seatLocator in seatLocators)
                    {
                        var seat = SeatManager.GetSeat(session, seatLocator.Item1, seatLocator.Item2);
                        viewModel.Tickets.Add(TicketManager.SellTicket(seat));
                    }
                }
                else
                {
                    viewModel.Errors.Add(Messages.SeatsNotFound);
                }
            }
            catch (Exception ex)
            {
                viewModel.Errors.Add(ex.Message);
            }

            if (viewModel.Errors.Count() <= 0)
            {
                DataContext.SaveChanges();
            }

            return View(viewModel);
        }

        private List<Tuple<int, int>> GetSeatLocators(string seats)
        {
            var retVal = new List<Tuple<int, int>>();

            var ss = seats.Split(',');

            foreach (var item in ss)
            {
                var seat = item.Split('_');
                retVal.Add(new Tuple<int, int>(int.Parse(seat[0]), int.Parse(seat[1])));
            }

            return retVal;
        }
    }
}