using Cinematic.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinematic.Web.Models.SessionViewModels
{
    public class SessionsEditViewModel : SessionsViewModel
    {
        public int SessionId { get; set; }

        [Display(ResourceType = typeof(Literals), Name = "Entity_Session_Status_DisplayName")]
        public SessionStatus Status { get; set; }

        public string ToNextStatus1 { get; set; }
        public string ToNextStatus2 { get; set; }

        public SessionsEditViewModel(Session session)
        {
            SessionId = session.Id;
            TimeAndDate = session.TimeAndDate;
            Status = session.Status;
            ToNextStatus1 = null;
            ToNextStatus2 = null;

            if (Status == SessionStatus.Open)
            {
                ToNextStatus1 = Literals.Close;
                ToNextStatus2 = Literals.Cancel;
            }

            if (Status == SessionStatus.Cancelled)
                ToNextStatus1 = Literals.Close;
        }

        public SessionsEditViewModel() { }
    }
}
