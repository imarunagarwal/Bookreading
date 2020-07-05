using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.Training.MVC.DAL
{
    public class BookReadingEventInitializer : DropCreateDatabaseIfModelChanges<BookReadingEventContext>
    {
        protected override void Seed(BookReadingEventContext context)
        {
            var events = new List<EventEntity>
            {
            new EventEntity{Title="Fire and Ice",Date=DateTime.Parse("2005-09-01"),Location="Delhi",Starttime=null,Type=Type.Public,Durationinhours=3,Description="Wrote by George RR Martin",OtherDetails="There is a TV series Based on his Books",EventInvites="arun@nagarro.com,shivam@nagarro.com,anuj@nagarro.com",PeopleInvited=3,UserID=2},
            new EventEntity{Title="Harry Potter and Chamber of secrets",Date=DateTime.Parse("2003-09-01"),Location="Delhi",Starttime=null,Type=Type.Private,Durationinhours=3,Description="Whole story revolved about a magic school",OtherDetails="There were 8 movies in this series",EventInvites="arun@nagarro.com,shivam@nagarro.com",PeopleInvited=2,UserID=3},
new EventEntity{Title="Harry Potter and Chamber of secrets",Date=DateTime.Parse("2003-09-01"),Location="Delhi",Starttime=null,Type=Type.Public,Durationinhours=3,Description="This book was written by CHE GUEVARA",OtherDetails="He travelled a lot on his bike with his friend and put all events in this book.",EventInvites="arun@nagarro.com,shivam@nagarro.com",PeopleInvited=2,UserID=4}
            };
            events.ForEach(e => context.EventEntity.Add(e));
            context.SaveChanges();


            var comments = new List<CommentsEntity>
            {
            new CommentsEntity{EventID=1,PostDate=DateTime.Parse("2005-12-01"),Comment="Interested"},
            new CommentsEntity{EventID=1,PostDate=DateTime.Parse("2004-12-01"),Comment="Great"},
            new CommentsEntity{EventID=2,PostDate=DateTime.Parse("2005-12-01"),Comment="Interested"},
            new CommentsEntity{EventID=2,PostDate=DateTime.Parse("2004-12-01"),Comment="Great"},
            };
            comments.ForEach(e => context.CommentsEntity.Add(e));
            context.SaveChanges();


            var invites = new List<EventInvitesEntity>
            {
            new EventInvitesEntity{EventID=1,EmailID="arun@nagarro.com"},
            new EventInvitesEntity{EventID=1,EmailID="shivam@nagarro.com"},
            new EventInvitesEntity{EventID=1,EmailID="anuj@nagarro.com"},
            new EventInvitesEntity{EventID=2,EmailID="arun@nagarro.com"},
            new EventInvitesEntity{EventID=2,EmailID="shivam@nagarro.com"},

            };
            invites.ForEach(e => context.EventInvitesEntity.Add(e));
            context.SaveChanges();


            var  users= new List<UserEntity>
            {
            new UserEntity{UserID=1,EmailID="myadmin@bookevents.com",Password="123@star",FullName="admin"},
            new UserEntity{UserID=2,EmailID="arun@nagarro.com",Password="123@star",FullName="Arun"},
            new UserEntity{UserID=3,EmailID="shivam@nagarro.com",Password="123@star",FullName="Sivam"},
            new UserEntity{UserID=4,EmailID="anuj@nagarro.com",Password="123@star",FullName="Anuj"},
            };
            users.ForEach(e => context.UserEntity.Add(e));
            context.SaveChanges();

        }
    }
}