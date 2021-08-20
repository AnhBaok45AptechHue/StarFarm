namespace StarFarm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changepricetodouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "Price", c => c.Single(nullable: false));
        }
    }
}
