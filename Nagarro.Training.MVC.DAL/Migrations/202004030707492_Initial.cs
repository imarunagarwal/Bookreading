namespace Nagarro.Training.MVC.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommentsEntity",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        EventID = c.Int(nullable: false),
                        PostDate = c.DateTime(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.CommentID);
            
            CreateTable(
                "dbo.EventEntity",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Date = c.DateTime(nullable: false),
                        Location = c.String(),
                        Starttime = c.DateTime(),
                        Type = c.Int(nullable: false),
                        Durationinhours = c.Single(),
                        Description = c.String(),
                        OtherDetails = c.String(),
                        EventInvites = c.String(),
                        PeopleInvited = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventID);
            
            CreateTable(
                "dbo.EventInvitesEntity",
                c => new
                    {
                        EventID = c.Int(nullable: false),
                        EmailID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.EventID, t.EmailID });
            
            CreateTable(
                "dbo.UserEntity",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        EmailID = c.String(),
                        Password = c.String(),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserEntity");
            DropTable("dbo.EventInvitesEntity");
            DropTable("dbo.EventEntity");
            DropTable("dbo.CommentsEntity");
        }
    }
}
