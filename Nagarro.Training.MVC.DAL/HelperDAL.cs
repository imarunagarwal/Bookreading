using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.Training.MVC.DAL;
using Nagarro.Training.MVC.Shared;

namespace Nagarro.Training.MVC.DAL
{
    public class HelperDAL :AutoMapper.Profile
    {
        public HelperDAL()
        {
            CreateMap<EventDTO,EventEntity>();
        }

    }
}
