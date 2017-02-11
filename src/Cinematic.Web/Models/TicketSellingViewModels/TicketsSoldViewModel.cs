using System.Collections.Generic;
using Cinematic.Domain;

namespace Cinematic.Web.Models.TicketSellingViewModels
{
    public class TicketsSoldViewModel
    {
        /// <summary>
        /// Inicializa una instancia de <see cref="TicketsSoldViewModel"/>
        /// </summary>
        public TicketsSoldViewModel()
        {
            this.Errors = new List<string>();
            this.Tickets = new List<Ticket>();
        }

        /// <summary>
        /// Entradas emitidas
        /// </summary>
        public IList<Ticket> Tickets { get; set; }

        /// <summary>
        /// Errores que han impedido que la cventa se realice
        /// </summary>
        public IList<string> Errors { get; set; }
    }
}