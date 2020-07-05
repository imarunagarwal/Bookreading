using Nagarro.Training.MVC.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nagarro.Training.MVC.BAL.Interfaces
{
    public interface IEventBusinessLogic
    {
        EventDTO AddEventBAL(EventDTO eventDTO);

        IList<string> AddInvitesBAL(IList<string> invites, int eventID);

        IList<EventDTO> ViewEventsInvitedToBAL(int userID);

        IList<EventDTO> ViewMyEventsBAL(int userID);

        IList<EventDTO> AllEventsForAdminBAL();

        IList<EventDTO> ViewPublicEventBAL();

        IList<EventDTO> ViewAllEventBAL(int userID);

        EventDTO GetEventBAL(int eventID);

        CommentsDTO AddCommentBAL(CommentsDTO comment);

        IList<CommentsDTO> GetCommentsBAL(int eventID);

        EventDTO EditEventBAL(EventDTO eventDTO);

        bool DeleteEventBAL(int id);

    }
}
