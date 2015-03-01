namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedbangelements : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Card", "Expansion");
            DropColumn("dbo.Card", "ExpansionString");
            DropColumn("dbo.Card", "Cardtype");
            DropColumn("dbo.Card", "CardTypeString");
            DropColumn("dbo.Card", "Suit");
            DropColumn("dbo.Card", "SuitString");
            DropColumn("dbo.Card", "Range");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Card", "Range", c => c.Int());
            AddColumn("dbo.Card", "SuitString", c => c.String());
            AddColumn("dbo.Card", "Suit", c => c.Int(nullable: false));
            AddColumn("dbo.Card", "CardTypeString", c => c.String());
            AddColumn("dbo.Card", "Cardtype", c => c.Int(nullable: false));
            AddColumn("dbo.Card", "ExpansionString", c => c.String());
            AddColumn("dbo.Card", "Expansion", c => c.Int(nullable: false));
        }
    }
}
