namespace JukeBox1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableRenaming : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.GenresModels", newName: "Genres");
            RenameTable(name: "dbo.PlaylistsModels", newName: "Playlists");
            RenameTable(name: "dbo.SongsModels", newName: "Songs");
            RenameTable(name: "dbo.AspNetUsers", newName: "Users");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Songs", newName: "SongsModels");
            RenameTable(name: "dbo.Playlists", newName: "PlaylistsModels");
            RenameTable(name: "dbo.Genres", newName: "GenresModels");
        }
    }
}
