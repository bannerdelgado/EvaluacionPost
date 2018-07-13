namespace ExampleWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChaneFieds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Weathers", "CityId", c => c.Int(nullable: false));
            CreateIndex("dbo.Weathers", "CityId");
            AddForeignKey("dbo.Weathers", "CityId", "dbo.Cities", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Weathers", "CityId", "dbo.Cities");
            DropIndex("dbo.Weathers", new[] { "CityId" });
            DropColumn("dbo.Weathers", "CityId");
        }
    }
}
