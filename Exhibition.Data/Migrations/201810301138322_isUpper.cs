namespace Exhibition.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isUpper : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TemplateSettings", "isFNtoupper", c => c.Boolean(nullable: false));
            AddColumn("dbo.TemplateSettings", "isLNtoupper", c => c.Boolean(nullable: false));
            AddColumn("dbo.TemplateSettings", "isPAtoupper", c => c.Boolean(nullable: false));
            AddColumn("dbo.TemplateSettings", "isPOtoupper", c => c.Boolean(nullable: false));
            AddColumn("dbo.TemplateSettings", "isCOtoupper", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TemplateSettings", "isCOtoupper");
            DropColumn("dbo.TemplateSettings", "isPOtoupper");
            DropColumn("dbo.TemplateSettings", "isPAtoupper");
            DropColumn("dbo.TemplateSettings", "isLNtoupper");
            DropColumn("dbo.TemplateSettings", "isFNtoupper");
        }
    }
}
