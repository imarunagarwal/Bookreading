using Nagarro.Training.MVC.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.Training.MVC.DAL.EntityDALs
{
    public interface IEventDAL
    {
        CommentsDTO AddCommentDAL(CommentsDTO comment);

        //EventDTO PopulateEventInvites(int eventID, string eventInviteList);

        IList<string> AddInvitesDAL(IList<string> invites, int eventID);

        EventDTO AddEvent(EventDTO eventDTO);

        IList<EventDTO> ViewPublicEvents();

        IList<EventDTO> ViewAllEvents(int userID);

        IList<EventDTO> ViewEventsInvitedToDAL(int userID);
     
        IList<EventDTO> ViewMyEventsDAL(int userID);

        IList<EventDTO> AllEventsForAdminDAL();
        
        EventDTO GetEventDAL(int eventID);
        
        IList<CommentsDTO> GetComments(int eventID);
        
        EventDTO EditEventDAL(EventDTO eventDTO);
        
        bool DeleteEventDAL(int id);

    }
}
