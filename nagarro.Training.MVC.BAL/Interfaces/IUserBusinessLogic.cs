using Nagarro.Training.MVC.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nagarro.Training.MVC.BAL.Interfaces
{
    public interface IUserBusinessLogic
    {
        UserDTO CreateUserBAL(UserDTO userDTO);
        
        UserDTO LoginUserBAL(UserDTO userDTO);

        UserDTO GetUserBAL(int userID);

        UserDTO EditUserBAL(UserDTO userDTO);

    }
}
