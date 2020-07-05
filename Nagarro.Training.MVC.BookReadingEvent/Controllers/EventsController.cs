using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Nagarro.Training.MVC.BookReadingEvent.Models;
using Nagarro.Training.MVC.Shared;
using nagarro.Training.MVC.BAL;
using System;
using Nagarro.Training.MVC.BookReadingEvent.Filters;
using nagarro.Training.MVC.BAL.Interfaces;
using System.Linq;
using Type = Nagarro.Training.MVC.BookReadingEvent.Models.Type;

namespace Nagarro.Training.MVC.BookReadingEvent.Controllers
{
    /// <summary>
    /// Events Controller to Control All Operations on Events
    /// </summary>
    public class EventsController : Controller
    {
        private IMapper mapEventViewModel2DTO;
        private IMapper mapEventDTO2ViewModel;
        private readonly IMapper mapCommentsViewModel2DTO;
        private IMapper mapCommentsDTO2ViewModel;
        private EventDTO eventDTO;
        private EventViewModel eventViewModel;
        private IList<CommentsViewModel> commentsViewModels;
        private IEventBusinessLogic eventBusinessLogic = new EventBusinessLogic();

        /// <summary>
        /// Constructor For Event Controller.
        /// </summary>
        public EventsController()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EventViewModel, EventDTO>();
            }
            );
            mapEventViewModel2DTO = mapperConfiguration.CreateMapper();

            MapperConfiguration mapperConfiguration1 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EventDTO, EventViewModel>();
            }
            );
            mapEventDTO2ViewModel = mapperConfiguration1.CreateMapper();

            MapperConfiguration mapperConfiguration2 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CommentsViewModel, CommentsDTO>();
            }
            );
            mapCommentsViewModel2DTO = mapperConfiguration2.CreateMapper();

            MapperConfiguration mapperConfiguration3 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CommentsDTO, CommentsViewModel>();
            }
            );
            mapCommentsDTO2ViewModel = mapperConfiguration3.CreateMapper();

        }

        /// <summary>
        /// Get Request of Create Event
        /// </summary>
        /// <returns></returns>
        [AuthenticateFilter]
        public ActionResult Create()
        {
            return View();
        }


        /// <summary>
        /// Post request of Create.
        /// </summary>
        /// <param name="eventViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthenticateFilter]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Date,Location,Starttime,Type,Durationinhours,Description,OtherDetails,EventInvites")] EventViewModel eventViewModel)
        {
            if (ModelState.IsValid)
            {
                if (eventViewModel.EventInvites == "")
                {
                    eventViewModel.EventInvites = string.Concat(eventViewModel.EventInvites, Session[Resource.EmailID]);
                }
                else
                {
                    eventViewModel.EventInvites = string.Concat(eventViewModel.EventInvites, "," + Session[Resource.EmailID]);
                }

                IList<string> invites = eventViewModel.EventInvites.Split(new char[] { ',' },StringSplitOptions.RemoveEmptyEntries).ToList();
                eventViewModel.PeopleInvited = invites.Count();
                eventViewModel.UserID = (int)Session[Resource.UserID];
                eventDTO = mapEventViewModel2DTO.Map<EventDTO>(eventViewModel);
                eventDTO = eventBusinessLogic.AddEventBAL(eventDTO);
                eventBusinessLogic.AddInvitesBAL(invites, eventDTO.EventID);

                return RedirectToAction(Resource.Index);
            }

            return View(eventViewModel);
        }


        /// <summary>
        /// Display Events 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            SeprateEventsOnDate seprateEventsOnDate = new SeprateEventsOnDate();
            if (Session[Resource.UserID] == null)
            {
                IList<EventViewModel> eventViewModels = mapEventDTO2ViewModel.Map<IList<EventViewModel>>(eventBusinessLogic.ViewPublicEventBAL());
                seprateEventsOnDate = SeprateEventsOnDate.SeprateEvents(eventViewModels);
            }
            else
            {
                IList<EventViewModel> eventViewModels = mapEventDTO2ViewModel.Map<IList<EventViewModel>>(eventBusinessLogic.ViewAllEventBAL((int)Session["UserID"]));
                seprateEventsOnDate = SeprateEventsOnDate.SeprateEvents(eventViewModels);
            }
            return View(seprateEventsOnDate);
        }


        /// <summary>
        /// Update newly posted Comment.
        /// </summary>
        /// <param name="comment"></param>
        /// <param name="eventID"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateComment(string comment, int eventID)
        {
            CommentsViewModel commentsViewModel = new CommentsViewModel
            {
                Comment = comment,
                PostDate = DateTime.Now.Date,
                EventID = eventID
            };

            CommentsDTO commentsDTO = mapCommentsDTO2ViewModel.Map<CommentsDTO>(commentsViewModel);
            eventBusinessLogic.AddCommentBAL(commentsDTO);
            return RedirectToAction(Resource.Details, Resource.Events, new { id = eventID });
        }


        /// <summary>
        /// Returns details of Event
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Object</returns>
        public ActionResult Details(int id)
        {
            ViewResult view;
            eventDTO = eventBusinessLogic.GetEventBAL(id);
            eventViewModel = mapEventDTO2ViewModel.Map<EventViewModel>(eventDTO);
            commentsViewModels = mapCommentsDTO2ViewModel.Map<IList<CommentsViewModel>>(eventBusinessLogic.GetCommentsBAL(id));

            if (eventViewModel == null)
            {
                return HttpNotFound();
            }
            else if (eventViewModel.Type == Type.Private && Session[Resource.UserID] == null)
            {
                view = View(Resource.ErrorPage);
            }
            else
            {
                EventDetailsWrapperClass eventDetailsWrapperClass = new EventDetailsWrapperClass(eventViewModel, commentsViewModels);
                view = View(eventDetailsWrapperClass);
            }
            return view;
        }


        /// <summary>
        /// Get request of edit.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AuthenticateFilter]
        public ActionResult Edit(int id)
        {
            ViewResult view;
            eventDTO = eventBusinessLogic.GetEventBAL(id);
            eventViewModel = mapEventDTO2ViewModel.Map<EventViewModel>(eventDTO);
            if (eventViewModel == null)
            {
                return HttpNotFound();
            }

            else if (eventViewModel.UserID == (int)Session[Resource.UserID])
            {
                view = View(eventViewModel);
            }

            else
            {
                view = View(Resource.ErrorPage);
            }
            return view;
        }


        /// <summary>
        /// To edit details of an event
        /// </summary>
        /// <param name="eventViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthenticateFilter]
        public ActionResult Edit([Bind(Include = "EventID,Title,Date,Location,Starttime,Type,Durationinhours,Description,OtherDetails,EventInvites,PeopleInvited,UserID")] EventViewModel eventViewModel)
        {
            EventViewModel eventOldData = mapEventDTO2ViewModel.Map<EventViewModel>(eventBusinessLogic.GetEventBAL(eventViewModel.EventID));

            if (eventViewModel.UserID == (int)Session[Resource.UserID])
            {
                if (TryUpdateModel(eventOldData, "", new string[] { "EventID", "Title", "Date", "Location", "Starttime", "Type", "Durationinhours", "Description", "OtherDetails", "EventInvites", "PeopleInvited", "UserID" }))
                {
                    if (eventOldData.EventInvites == "")
                    {
                        eventOldData.EventInvites = string.Concat(eventViewModel.EventInvites, Session[Resource.EmailID]);
                    }
                    else
                    {
                        eventOldData.EventInvites = string.Concat(eventViewModel.EventInvites, "," + Session[Resource.EmailID]);
                    }
                    IList<string> invites = eventOldData.EventInvites.Split(',').ToList();
                    eventOldData.PeopleInvited = invites.Count();
                    EventDTO eventDTO = mapEventViewModel2DTO.Map<EventDTO>(eventOldData);
                    eventBusinessLogic.EditEventBAL(eventDTO);
                    return RedirectToAction(Resource.Index);
                }
                else
                {
                    return View(eventViewModel);
                }
            }
            else
            {
                return View(Resource.ErrorPage);
            }
        }


        /// <summary>
        /// Method to Display list of Events in Which User is Invited.
        /// </summary>
        /// <returns></returns>
        public ActionResult EventsInvitedTo()
        {
            int.TryParse(Session[Resource.UserID].ToString(), out int userID);
            IList<EventViewModel> eventViewModels = mapEventDTO2ViewModel.Map<IList<EventViewModel>>(eventBusinessLogic.ViewEventsInvitedToBAL(userID));
            return View(eventViewModels);
        }


        /// <summary>
        /// Method to display Events Created by user.
        /// </summary>
        /// <returns></returns>
        public ActionResult MyEvents()
        {
            int.TryParse(Session[Resource.UserID].ToString(), out int userID);
            IList<EventViewModel> eventViewModels = mapEventDTO2ViewModel.Map<IList<EventViewModel>>(eventBusinessLogic.ViewMyEventsBAL(userID));
            return View(eventViewModels);
        }


        /// <summary>
        /// Method to view All Events for Admin.
        /// </summary>
        /// <returns></returns>

        public ActionResult AllEventsForAdmin()
        {
            IList<EventViewModel> eventViewModels = mapEventDTO2ViewModel.Map<IList<EventViewModel>>(eventBusinessLogic.AllEventsForAdminBAL());
            return View(eventViewModels);
        }


        /// <summary>
        /// Redirects to delete confirm page.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Details of event to be deleted</returns>
        //[AuthenticateFilter]
        //public ActionResult Delete(int id)
        //{
        //    EventViewModel eventViewModel = mapDTO2ViewModel.Map<EventViewModel>(eventBusinessLogic.GetEventBAL(id));

        //    if (eventViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(eventViewModel);
        //}



        /// <summary>
        /// Confirm Delete to avoid click by mistake. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Deletes the event</returns>
        //[HttpPost, ActionName("Delete")]
        //[AuthenticateFilter]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    eventBusinessLogic.DeleteEventBAL(id);
        //    return RedirectToAction(Resource.Index);
        //}
    }
}
