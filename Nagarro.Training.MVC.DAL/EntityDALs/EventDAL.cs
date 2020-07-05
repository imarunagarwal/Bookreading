using AutoMapper;
using Nagarro.Training.MVC.DAL.EntityDALs;
using Nagarro.Training.MVC.Shared;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Nagarro.Training.MVC.DAL
{
    /// <summary>
    /// Class to Manipulate Events.
    /// </summary>
    public class EventDAL : IEventDAL
    {
        private IMapper mapEventDTO2Entity;
        private IMapper mapEventEntity2DTO;
        private IMapper mapCommentDTO2Entity;
        private IMapper mapCommentEntity2DTO;


        /// <summary>
        /// Constructor for EventDAL
        /// </summary>
        public EventDAL()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<EventDTO, EventEntity>();
                }
            );
            mapEventDTO2Entity = mapperConfiguration.CreateMapper();


            MapperConfiguration mapperConfiguration1 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EventEntity, EventDTO>();
            }
            );
            mapEventEntity2DTO = mapperConfiguration1.CreateMapper();


            MapperConfiguration mapperConfiguration2 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CommentsEntity, CommentsDTO>();
            }
            );
            mapCommentEntity2DTO = mapperConfiguration2.CreateMapper();


            MapperConfiguration mapperConfiguration3 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CommentsDTO, CommentsEntity>();
            }
            );
            mapCommentDTO2Entity = mapperConfiguration3.CreateMapper();
        }


        /// <summary>
        /// populate Event recipients List.
        /// </summary>
        /// <param name="eventID"></param>
        /// <param name="eventInviteList"></param>
        public IList<string> AddInvitesDAL(IList<string> invites, int eventID)
        {
            try
            {
                using (BookReadingEventContext db = new BookReadingEventContext())
                {
                    foreach (var item in invites)
                    {
                        EventInvitesEntity eventInvitesEntity = new EventInvitesEntity
                        {
                            EventID = eventID,
                            EmailID = item
                        };
                        db.EventInvitesEntity.Add(eventInvitesEntity);
                    }
                    db.SaveChanges();
                }
                return invites;
            }
            catch (Exception)
            {
                throw new DALException(Resource.DALErrorMessage);
            }
        }


        /// <summary>
        /// Add a comment to DataBase
        /// </summary>
        /// <param name="comment"></param>
        public CommentsDTO AddCommentDAL(CommentsDTO comment)
        {
            try
            {
                using (BookReadingEventContext db = new BookReadingEventContext())
                {
                    CommentsEntity commentsEntity = mapCommentDTO2Entity.Map<CommentsEntity>(comment);
                    db.CommentsEntity.Add(commentsEntity);
                    db.SaveChanges();
                    return comment;
                }
            }
            catch (Exception)
            {
                throw new DALException(Resource.DALErrorMessage);
            }
        }


        /// <summary>
        /// Add an Event to DataBase.
        /// </summary>
        /// <param name="eventDTO"></param>
        /// <returns></returns>
        public EventDTO AddEvent(EventDTO eventDTO)
        {
            try
            {
                using (BookReadingEventContext db = new BookReadingEventContext())
                {
                    EventEntity eventEntity = mapEventDTO2Entity.Map<EventEntity>(eventDTO);
                    db.EventEntity.Add(eventEntity);
                    db.SaveChanges();

                    EventEntity eventFetch = db.EventEntity.Where(s => (s.Title == eventEntity.Title && s.Starttime == eventEntity.Starttime && s.Location == eventEntity.Location)).FirstOrDefault();

                    //AddInvitesDAL(eventFetch.EventID, eventEntity.EventInvites);
                    eventDTO = mapEventEntity2DTO.Map<EventDTO>(eventFetch);

                    return eventDTO;
                }
            }
            catch (Exception)
            {
                throw new DALException(Resource.DALErrorMessage);
            }
        }


        /// <summary>
        /// view All public Events
        /// </summary>
        /// <returns></returns>
        public IList<EventDTO> ViewPublicEvents()
        {
            try
            {
                using (BookReadingEventContext db = new BookReadingEventContext())
                {
                    return mapEventEntity2DTO.Map<IList<EventDTO>>(db.EventEntity.Where(e => e.Type == Type.Public).ToList());

                }
            }
            catch (Exception)
            {
                throw new DALException(Resource.DALErrorMessage);
            }
        }


        /// <summary>
        /// View All Events.
        /// </summary>
        /// <returns></returns>
        public IList<EventDTO> ViewAllEvents(int userID)
        {
            try
            {
                using (BookReadingEventContext db = new BookReadingEventContext())
                {
                    IList<EventEntity> userEvents = db.EventEntity.Where(e => e.UserID == userID).ToList();
                    IList<EventEntity> publicEvents = db.EventEntity.Where(e => e.Type == Type.Public && e.UserID != userID).ToList();

                    foreach (var item in publicEvents)
                    {
                        userEvents.Add(item);
                    }
                    return mapEventEntity2DTO.Map<IList<EventDTO>>(userEvents);
                }
            }
            catch (Exception)
            {
                throw new DALException(Resource.DALErrorMessage);
            }
        }


        /// <summary>
        /// View All Events for Admin.
        /// </summary>
        /// <returns></returns>
        public IList<EventDTO> AllEventsForAdminDAL()
        {
            try
            {
                using (BookReadingEventContext db = new BookReadingEventContext())
                {
                    return mapEventEntity2DTO.Map<IList<EventDTO>>(db.EventEntity.ToList());
                }
            }
            catch (Exception)
            {
                throw new DALException(Resource.DALErrorMessage);
            }
        }


        /// <summary>
        /// View List of people Invited to Event.
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public IList<EventDTO> ViewEventsInvitedToDAL(int userID)
        {
            try
            {
                using (BookReadingEventContext db = new BookReadingEventContext())
                {
                    UserEntity userEntity = db.UserEntity.Where(a => a.UserID == userID).FirstOrDefault();

                    IList<EventInvitesEntity> invites = db.EventInvitesEntity.Where(e => e.EmailID == userEntity.EmailID).ToList();

                    IList<EventDTO> eventsInvited = new List<EventDTO>();

                    foreach (var item in invites)
                    {
                        eventsInvited.Add(GetEventDAL(item.EventID));
                    }
                    return eventsInvited;
                }
            }
            catch (Exception)
            {
                throw new DALException(Resource.DALErrorMessage);
            }

        }


        /// <summary>
        /// View User's Events.
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public IList<EventDTO> ViewMyEventsDAL(int userID)
        {
            try
            {
                using (BookReadingEventContext db = new BookReadingEventContext())
                {
                    return mapEventEntity2DTO.Map<IList<EventDTO>>(db.EventEntity.Where(e => e.UserID == userID).ToList());
                }
            }
            catch (Exception)
            {
                throw new DALException(Resource.DALErrorMessage);
            }

        }


        /// <summary>
        /// get Details of Event having given eventID
        /// </summary>
        /// <param name="eventID"></param>
        /// <returns></returns>
        public EventDTO GetEventDAL(int eventID)
        {
            try
            {
                using (BookReadingEventContext db = new BookReadingEventContext())
                {
                    return mapEventEntity2DTO.Map<EventDTO>(db.EventEntity.Find(eventID));

                }
            }
            catch (Exception)
            {
                throw new DALException(Resource.DALErrorMessage);
            }
        }


        /// <summary>
        /// Get Comments on Event.
        /// </summary>
        /// <param name="eventID"></param>
        /// <returns></returns>
        public IList<CommentsDTO> GetComments(int eventID)
        {
            try
            {
                using (BookReadingEventContext db = new BookReadingEventContext())
                {
                    return mapCommentEntity2DTO.Map<IList<CommentsDTO>>(db.CommentsEntity.Where(p => p.EventID == eventID).ToList());
                }
            }
            catch (Exception)
            {
                throw new DALException(Resource.DALErrorMessage);
            }
        }


        /// <summary>
        /// Edit Event 
        /// </summary>
        /// <param name="eventDTO"></param>
        /// <returns></returns>
        public EventDTO EditEventDAL(EventDTO eventDTO)
        {
            try
            {
                using (BookReadingEventContext db = new BookReadingEventContext())
                {

                    EventEntity newEventEntity = mapEventDTO2Entity.Map<EventEntity>(eventDTO);
                    EventEntity oldEventEntity = db.EventEntity.Find(newEventEntity.EventID);
                    db.Entry(oldEventEntity).CurrentValues.SetValues(newEventEntity);
                    db.SaveChanges();
                    return eventDTO;
                }
            }
            catch (Exception)
            {
                throw new DALException(Resource.DALErrorMessage);
            }
        }


        /// <summary>
        /// Delete Event.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteEventDAL(int id)
        {
            try
            {
                using (BookReadingEventContext db = new BookReadingEventContext())
                {

                    EventEntity eventEntity = db.EventEntity.Find(id);
                    db.EventEntity.Remove(eventEntity);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                throw new DALException(Resource.DALErrorMessage);
            }

        }
    }
}