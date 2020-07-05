using Nagarro.Training.MVC.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.Training.MVC.DAL.EntityDALs
{
    public interface IUserDAL
    {
        UserDTO CreateUser(UserDTO userDTO);

        UserDTO LoginUser(UserDTO userDTO);

        UserDTO GetUserEntity(UserDTO userDTO);

        UserDTO GetUser(int userID);

        UserDTO EditUser(UserDTO userDTO);
    }
}
