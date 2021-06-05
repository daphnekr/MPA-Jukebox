namespace JukeBox1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnsToPlaylist : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlaylistsModels", "userId", c => c.Int(nullable: false));
            AddColumn("dbo.PlaylistsModels", "songsIds", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlaylistsModels", "songsIds");
            DropColumn("dbo.PlaylistsModels", "userId");
        }
    }
}
