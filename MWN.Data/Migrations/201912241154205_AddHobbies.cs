namespace MWN.Data
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHobbies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hobbies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicationUserHobbies",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Hobby_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Hobby_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Hobbies", t => t.Hobby_Id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Hobby_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUserHobbies", "Hobby_Id", "dbo.Hobbies");
            DropForeignKey("dbo.ApplicationUserHobbies", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserHobbies", new[] { "Hobby_Id" });
            DropIndex("dbo.ApplicationUserHobbies", new[] { "ApplicationUser_Id" });
            DropTable("dbo.ApplicationUserHobbies");
            DropTable("dbo.Hobbies");
        }
    }
}
