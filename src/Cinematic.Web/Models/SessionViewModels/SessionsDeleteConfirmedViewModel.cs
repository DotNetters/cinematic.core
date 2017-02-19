using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinematic.Web.Models.SessionViewModels
{
    public class SessionsDeleteConfirmedViewModel
    {
        public Session Session { get; set; }

        public CinematicException Exception { get; set; }
    }
}
