namespace Exhibition.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Exhibition.Data.SettingModel.ExhibitionSettingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Exhibition.Data.SettingModel.ExhibitionSettingContext";
        }

        protected override void Seed(Exhibition.Data.SettingModel.ExhibitionSettingContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
