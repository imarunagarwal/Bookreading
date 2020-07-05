using nagarro.Training.MVC.BAL.Interfaces;
using Nagarro.Training.MVC.DAL;
using Nagarro.Training.MVC.DAL.EntityDALs;
using Nagarro.Training.MVC.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nagarro.Training.MVC.BAL
{
    public class UserBusinessLogic : IUserBusinessLogic
    {
        private IUserDAL userDAL = new UserDAL();

        /// <summary>
        /// Business Method to Create new User
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        public UserDTO CreateUserBAL(UserDTO userDTO)
        {
            try
            {
                UserDTO user = userDAL.GetUserEntity(userDTO);
                if (user == null)
                {
                    return user = userDAL.CreateUser(userDTO);
                }
                return null;
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
        /// Business method to check Logging in user
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        public UserDTO LoginUserBAL(UserDTO userDTO)
        {
            try
            {
                UserDTO userFound = userDAL.LoginUser(userDTO);
                return userFound;
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
        /// business method to get User having userID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public UserDTO GetUserBAL(int userID)
        {
            try
            {
                return userDAL.GetUser(userID);
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
        /// Business method to Edit User.
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        public UserDTO EditUserBAL(UserDTO userDTO)
        {
            try
            {
                return userDAL.EditUser(userDTO);
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
