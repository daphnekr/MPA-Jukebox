namespace JukeBox1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_validation_playlistname : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PlaylistsModels", "playlistName", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PlaylistsModels", "playlistName", c => c.String(nullable: false));
        }
    }
}
