using nagarro.Training.MVC.BAL.Interfaces;
using Nagarro.Training.MVC.DAL;
using Nagarro.Training.MVC.DAL.EntityDALs;
using Nagarro.Training.MVC.Shared;
using System;
using System.Collections.Generic;

namespace nagarro.Training.MVC.BAL
{
    public class EventBusinessLogic : IEventBusinessLogic
    {
        private IEventDAL eventDAL = new EventDAL();


        /// <summary>
        /// Business method to Add Events
        /// </summary>
        /// <param name="eventDTO"></param>
        /// <returns></returns>
        public EventDTO AddEventBAL(EventDTO eventDTO)
        {
            try
            {
                return eventDAL.AddEvent(eventDTO);
            }
            catch (DALException dalEx)
            {
                throw new Exception(dalEx.Message);
            }
            catch (Exception)
            {
                throw new Exception(Resource.BALErrorMessage);
            }
        }


        /// <summary>
        /// Add invites to the Event.
        /// </summary>
        /// <param name="invites"></param>
        /// <param name="eventID"></param>
        /// <returns></returns>
        public IList<string> AddInvitesBAL(IList<string> invites, int eventID)
        {
            try
            {
                return eventDAL.AddInvitesDAL(invites, eventID);
            }
            catch (DALException dalEx)
            {
                throw new Exception(dalEx.Message);
            }
            catch (Exception)
            {
                throw new Exception(Resource.BALErrorMessage);
            }
        }


        /// <summary>
        /// Business method to View Events Invited to.
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public IList<EventDTO> ViewEventsInvitedToBAL(int userID)
        {
            try
            {
                return eventDAL.ViewEventsInvitedToDAL(userID);
            }
            catch (DALException dalEx)
            {
                throw new Exception(dalEx.Message);
            }
            catch (Exception)
            {
                throw new Exception(Resource.BALErrorMessage);
            }
        }


        /// <summary>
        /// Business method to View User's Events.
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public IList<EventDTO> ViewMyEventsBAL(int userID)
        {
            try
            {
                return eventDAL.ViewMyEventsDAL(userID);
            }
            catch (DALException dalEx)
            {
                throw new Exception(dalEx.Message);
            }
            catch (Exception)
            {
                throw new Exception(Resource.BALErrorMessage);
            }
        }


        /// <summary>
        /// Show All Events for Admin.
        /// </summary>
        /// <returns></returns>
        public IList<EventDTO> AllEventsForAdminBAL()
        {
            try
            {
                return eventDAL.AllEventsForAdminDAL();
            }
            catch (DALException dalEx)
            {
                throw new Exception(dalEx.Message);
            }
            catch (Exception)
            {
                throw new Exception(Resource.BALErrorMessage);
            }
        }


        /// <summary>
        /// Business method to view All public Events
        /// </summary>
        /// <returns></returns>
        public IList<EventDTO> ViewPublicEventBAL()
        {
            try
            {
                return eventDAL.ViewPublicEvents();
            }
            catch (DALException dalEx)
            {
                throw new Exception(dalEx.Message);
            }
            catch (Exception)
            {
                throw new Exception(Resource.BALErrorMessage);
            }
        }

        /// <summary>
        /// Business method to view All events.
        /// </summary>
        /// <returns></returns>
        public IList<EventDTO> ViewAllEventBAL(int userID)
        {
            try
            {
                return eventDAL.ViewAllEvents(userID);
            }
            catch (DALException dalEx)
            {
                throw new Exception(dalEx.Message);
            }
            catch (Exception)
            {
                throw new Exception(Resource.BALErrorMessage);
            }
        }


        /// <summary>
        /// Business method to get Events by EventID
        /// </summary>
        /// <param name="EventID"></param>
        /// <returns></returns>
        public EventDTO GetEventBAL(int EventID)
        {
            try
            {
                return eventDAL.GetEventDAL(EventID);
            }
            catch (DALException dalEx)
            {
                throw new Exception(dalEx.Message);
            }
            catch (Exception)
            {
                throw new Exception(Resource.BALErrorMessage);
            }
        }


        /// <summary>
        /// Business method to edit Events.
        /// </summary>
        /// <param name="eventDTO"></param>
        /// <returns></returns>
        public EventDTO EditEventBAL(EventDTO eventDTO)
        {
            try
            {
                return eventDAL.EditEventDAL(eventDTO);
            }
            catch (DALException dalEx)
            {
                throw new Exception(dalEx.Message);
            }
            catch (Exception)
            {
                throw new Exception(Resource.BALErrorMessage);
            }
        }


        /// <summary>
        /// Business method to Delete Events.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteEventBAL(int id)
        {
            try
            {
                eventDAL.DeleteEventDAL(id);
                return true;
            }
            catch (DALException dalEx)
            {
                throw new Exception(dalEx.Message);
            }
            catch (Exception)
            {
                throw new Exception(Resource.BALErrorMessage);
            }
        }


        /// <summary>
        /// business method to add comments.
        /// </summary>
        /// <param name="comment"></param>
        public CommentsDTO AddCommentBAL(CommentsDTO comment)
        {
            try
            {
                return eventDAL.AddCommentDAL(comment);
            }
            catch (DALException dalEx)
            {
                throw new Exception(dalEx.Message);
            }
            catch (Exception)
            {
                throw new Exception(Resource.BALErrorMessage);
            }
        }


        /// <summary>
        /// Business method to get comments on Event having EventID
        /// </summary>
        /// <param name="eventID"></param>
        /// <returns></returns>
        public IList<CommentsDTO> GetCommentsBAL(int eventID)
        {
            try
            { 
            return eventDAL.GetComments(eventID);
            }
            catch (DALException dalEx)
            {
                throw new Exception(dalEx.Message);
            }
            catch (Exception)
            {
                throw new Exception(Resource.BALErrorMessage);
            }
        }
    }
}
