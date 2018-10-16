namespace Exhibition.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExhibitionVisitors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        BarCode = c.String(),
                        Status = c.String(),
                        WorkPhone = c.String(),
                        Pathronim = c.String(),
                        CityId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        PositionId = c.Int(nullable: false),
                        DescriptionId = c.Int(nullable: false),
                        ExhibitId = c.Int(nullable: false),
                        RaportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Descriptions", t => t.DescriptionId, cascadeDelete: true)
                .ForeignKey("dbo.Exhibits", t => t.ExhibitId, cascadeDelete: true)
                .ForeignKey("dbo.Positions", t => t.PositionId, cascadeDelete: true)
                .ForeignKey("dbo.Raports", t => t.RaportId, cascadeDelete: true)
                .Index(t => t.CityId)
                .Index(t => t.CompanyId)
                .Index(t => t.PositionId)
                .Index(t => t.DescriptionId)
                .Index(t => t.ExhibitId)
                .Index(t => t.RaportId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Descriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Color = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Exhibits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Raports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExhibitionVisitors", "RaportId", "dbo.Raports");
            DropForeignKey("dbo.ExhibitionVisitors", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.ExhibitionVisitors", "ExhibitId", "dbo.Exhibits");
            DropForeignKey("dbo.ExhibitionVisitors", "DescriptionId", "dbo.Descriptions");
            DropForeignKey("dbo.ExhibitionVisitors", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.ExhibitionVisitors", "CityId", "dbo.Cities");
            DropIndex("dbo.ExhibitionVisitors", new[] { "RaportId" });
            DropIndex("dbo.ExhibitionVisitors", new[] { "ExhibitId" });
            DropIndex("dbo.ExhibitionVisitors", new[] { "DescriptionId" });
            DropIndex("dbo.ExhibitionVisitors", new[] { "PositionId" });
            DropIndex("dbo.ExhibitionVisitors", new[] { "CompanyId" });
            DropIndex("dbo.ExhibitionVisitors", new[] { "CityId" });
            DropTable("dbo.Raports");
            DropTable("dbo.Positions");
            DropTable("dbo.Exhibits");
            DropTable("dbo.Descriptions");
            DropTable("dbo.Companies");
            DropTable("dbo.ExhibitionVisitors");
            DropTable("dbo.Cities");
        }
    }
}
