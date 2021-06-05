namespace JukeBox1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class columnTypeChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PlaylistsModels", "userId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PlaylistsModels", "userId", c => c.Int(nullable: false));
        }
    }
}
