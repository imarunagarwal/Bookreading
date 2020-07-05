using Nagarro.Training.MVC.BookReadingEvent.Models;
using Nagarro.Training.MVC.Shared;

namespace Nagarro.Training.MVC.BookReadingEvent.Helper
{
    public class AutomapperProfile : AutoMapper.Profile
    {
        public AutomapperProfile()
        {
            CreateMap<EventViewModel,EventDTO>();
        }        
    }
}