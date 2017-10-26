namespace OnlineDbRepo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminMsts",
                c => new
                    {
                        AID = c.Int(nullable: false, identity: true),
                        Role = c.String(maxLength: 50),
                        UserName = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
                        EntryDate = c.DateTime(),
                        Email_Id = c.String(maxLength: 50),
                        Img = c.String(),
                        Register_Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.AID);
            
            CreateTable(
                "dbo.BookMsts",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        BookName = c.String(maxLength: 50),
                        Author = c.String(maxLength: 50),
                        Detail = c.String(maxLength: 50),
                        Price = c.Double(),
                        Publication = c.String(maxLength: 50),
                        Branch = c.String(maxLength: 50),
                        Quantities = c.Int(),
                        AvailableQnt = c.Int(),
                        RentQnt = c.Int(),
                        Image = c.String(maxLength: 1000),
                        BookPDF = c.String(maxLength: 1000),
                        EntryDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.BookID);
            
            CreateTable(
                "dbo.BranchMsts",
                c => new
                    {
                        BranchID = c.Int(nullable: false, identity: true),
                        BranchName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.BranchID);
            
            CreateTable(
                "dbo.PenaltyMsts",
                c => new
                    {
                        PID = c.Int(nullable: false, identity: true),
                        SID = c.Int(),
                        BookName = c.String(maxLength: 50),
                        Price = c.Double(),
                        Panalty = c.Double(),
                        Detail = c.String(maxLength: 500),
                        EntryDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.PID);
            
            CreateTable(
                "dbo.PublicationMsts",
                c => new
                    {
                        PID = c.Int(nullable: false, identity: true),
                        Publication = c.String(maxLength: 100),
                        EntryDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.PID);
            
            CreateTable(
                "dbo.RentMsts",
                c => new
                    {
                        RID = c.Int(nullable: false, identity: true),
                        BookName = c.String(maxLength: 50),
                        SID = c.Int(),
                        Days = c.Int(),
                        IssueDate = c.DateTime(),
                        ReturnDate = c.DateTime(),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.RID);
            
            CreateTable(
                "dbo.StudentMsts",
                c => new
                    {
                        SID = c.Int(nullable: false, identity: true),
                        StudentName = c.String(maxLength: 50),
                        BranchName = c.String(maxLength: 50),
                        Mobile = c.String(maxLength: 50),
                        Address = c.String(maxLength: 50),
                        City = c.String(maxLength: 50),
                        Pincode = c.String(maxLength: 50),
                        DOB = c.DateTime(),
                        Gender = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
                        Image = c.String(maxLength: 500),
                        EntryDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.SID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StudentMsts");
            DropTable("dbo.RentMsts");
            DropTable("dbo.PublicationMsts");
            DropTable("dbo.PenaltyMsts");
            DropTable("dbo.BranchMsts");
            DropTable("dbo.BookMsts");
            DropTable("dbo.AdminMsts");
        }
    }
}
