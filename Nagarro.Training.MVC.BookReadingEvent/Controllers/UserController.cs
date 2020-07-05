using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using nagarro.Training.MVC.BAL;
using nagarro.Training.MVC.BAL.Interfaces;
using Nagarro.Training.MVC.BookReadingEvent.Models;
using Nagarro.Training.MVC.Shared;

namespace Nagarro.Training.MVC.BookReadingEvent.Controllers
{
    /// <summary>
    /// Controller to implement all Operations on user.
    /// </summary>
    public class UserController : Controller
    {
        private IMapper mapUserViewModel2DTO;
        private IMapper mapUserDTO2ViewModel;
        private UserDTO userDTO;
        private UserViewModel userViewModel;
        private IUserBusinessLogic userBusinessLogic = new UserBusinessLogic();

        /// <summary>
        /// Constructor of Controller
        /// </summary>
        public UserController()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<EventViewModel, EventDTO>();
                }
            );
            mapUserViewModel2DTO = mapperConfiguration.CreateMapper();

            MapperConfiguration mapperConfiguration1 = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<EventDTO, EventViewModel>();
                }
            );
            mapUserDTO2ViewModel = mapperConfiguration.CreateMapper();
        }

        /// <summary>
        /// Create New User
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Post Request of Create User
        /// </summary>
        /// <param name="userViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmailID,Password,FullName")] UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                userDTO = mapUserViewModel2DTO.Map<UserDTO>(userViewModel);
                userDTO =userBusinessLogic.CreateUserBAL(userDTO);
                if(userDTO==null)
                {
                    return View(Resource.Login);
                }
                Session[Resource.UserID] = userDTO.UserID;
                return RedirectToAction(Resource.Index,Resource.Events);
            }
            return View(userViewModel);
        }

        /// <summary>
        /// Login Request of existing user
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Post request of Login  
        /// </summary>
        /// <param name="userViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "EmailID,Password")] UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                userDTO = mapUserViewModel2DTO.Map<UserDTO>(userViewModel);
                userDTO = userBusinessLogic.LoginUserBAL(userDTO);
                if (userDTO !=null)
                {
                    Session[Resource.EmailID] =userDTO.EmailID;
                    Session[Resource.UserID] = userDTO.UserID;
                    return RedirectToAction(Resource.Index, Resource.Events);
                }
                
            }
            ModelState.AddModelError("", "Wrong Email ID or password.");
            //return RedirectToAction(Resource.Login);
            return View(userViewModel);
        }

        /// <summary>
        /// LogOut Request for Logged in User.
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            Session.Remove(Resource.UserID);
            return RedirectToAction(Resource.Index, Resource.Events);
        }

        /// <summary>
        /// Edit Details of user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public ActionResult Edit(int id)
        //{
        //    userViewModel = mapUserDTO2ViewModel.Map<UserViewModel>(userBusinessLogic.GetUserBAL(id));
        //    if (userViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    userViewModel.UserID = id;
        //    return View(userViewModel);
        //}

        ///// <summary>
        ///// Post request of Edit User Details
        ///// </summary>
        ///// <param name="userViewModel"></param>
        ///// <returns></returns>
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "UserID,EmailID,Password,FullName")] UserViewModel userViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        userDTO= mapUserViewModel2DTO.Map<UserDTO>(userViewModel);
        //        userBusinessLogic.EditUserBAL(userDTO);

        //        return RedirectToAction("Index");
        //    }
        //    return View(userViewModel);
        //}
    }
}
