namespace BusinessLogic.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class addedRarityToCards : DbMigration
	{
		public override void Up()
		{
			AddColumn("dbo.Card", "Rarity", c => c.Int(nullable: false, defaultValue: 0));
		}

		public override void Down()
		{
			DropColumn("dbo.Card", "Rarity");
		}
	}
}