namespace Exhibition.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class date_created : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExhibitionVisitors", "DateCreated", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExhibitionVisitors", "DateCreated");
        }
    }
}
