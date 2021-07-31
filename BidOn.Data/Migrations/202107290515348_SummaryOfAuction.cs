namespace BidOn.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SummaryOfAuction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Auctions", "Summery", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Auctions", "Summery");
        }
    }
}
