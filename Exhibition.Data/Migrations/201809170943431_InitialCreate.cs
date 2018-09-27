namespace Exhibition.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExhibitionSVisitors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Company = c.String(),
                        Position = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        BarCode = c.String(),
                        Description = c.String(),
                        Status = c.String(),
                        Exhibition = c.String(),
                        City = c.String(),
                        Raport = c.String(),
                        WorkPhone = c.String(),
                        Pathronim = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ExhibitionSVisitors");
        }
    }
}
