namespace JukeBox1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumnCorrection : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SavedSongsModels", "playlistId");
            DropColumn("dbo.SavedSongsModels", "songsIds");
            DropColumn("dbo.SongsModels", "genreId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SongsModels", "genreId", c => c.Int(nullable: false));
            AddColumn("dbo.SavedSongsModels", "songsIds", c => c.String());
            AddColumn("dbo.SavedSongsModels", "playlistId", c => c.Int(nullable: false));
        }
    }
}
