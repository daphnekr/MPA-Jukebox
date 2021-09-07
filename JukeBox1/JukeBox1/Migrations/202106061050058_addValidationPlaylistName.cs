namespace JukeBox1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addValidationPlaylistName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PlaylistsModels", "playlistName", c => c.String(nullable: false, maxLength: 60));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PlaylistsModels", "playlistName", c => c.String(nullable: false));
        }
    }
}
