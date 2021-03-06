﻿using Cinematic.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinematic.Resources;
using Cinematic.Infrastructure;

namespace Cinematic
{
    /// <summary>
    /// Servicio que gestiona la venta de tickets
    /// </summary>
    public class TicketManager : ITicketManager
    {
        ISeatManager SeatManager { get; set; } = null;
        IPriceManager PriceManager { get; set; } = null;
        IDataContext DataContext { get; set; } = null;

        /// <summary>
        /// Inicializa una intancia de <see cref="TicketManager"/>
        /// </summary>
        /// <param name="seatManager">Instancia de <see cref="ISeatManager"/></param>
        /// <param name="priceManager">Instancia de <see cref="IPriceManager"/></param>
        /// <param name="dataContext">Instancia de <see cref="IDataContext"/></param>
        public TicketManager(ISeatManager seatManager, IPriceManager priceManager, IDataContext dataContext)
        {
            if (seatManager == null)
                throw new ArgumentNullException("seatManager");
            if (priceManager == null)
                throw new ArgumentNullException("priceManager");
            if (dataContext == null)
                throw new ArgumentNullException("dataContext");

            SeatManager = seatManager;
            PriceManager = priceManager;
            DataContext = dataContext;
        }

        /// <inheritdoc />
        public Ticket SellTicket(Seat seat)
        {
            if (seat == null)
                throw new ArgumentNullException("seat");

            if (seat.Session == null)
                throw new ArgumentNullException("seat.Session");

            if (seat.Session.Status == SessionStatus.Closed)
                throw new CinematicException(Messages.SessionIsClosedNoTicketsAvailable);

            if (seat.Session.Status == SessionStatus.Cancelled)
                throw new CinematicException(Messages.SessionIsCancelledNoTicketsAvailable);

            var allocatedSeat = SeatManager.AllocateSeat(seat);

            var newTicket = new Ticket()
            {
                Price = PriceManager.GetTicketPrice(allocatedSeat.Session, allocatedSeat.Row, allocatedSeat.SeatNumber),
                Seat = allocatedSeat,
                TimeAndDate = SystemTime.Now()
            };

            DataContext.Add(newTicket);

            return (newTicket);
        }

        /// <inheritdoc />
        public void CancelTicket(Ticket ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException("ticket");

            if (ticket.Seat == null)
                throw new ArgumentNullException("ticket.Seat");

            if (ticket.Seat.Session == null)
                throw new ArgumentNullException("ticket.Seat.Session");

            if (ticket.Seat.Session.Status == SessionStatus.Closed)
                throw new CinematicException(Messages.SessionIsClosedCannotReturnTickets);

            SeatManager.DeallocateSeat(ticket.Seat);

            DataContext.Remove(ticket);
        }
    }
}
