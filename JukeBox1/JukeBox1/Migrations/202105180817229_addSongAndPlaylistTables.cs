namespace JukeBox1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSongAndPlaylistTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlaylistsModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        playlistName = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.SavedSongsModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        playlistId = c.Int(nullable: false),
                        songsIds = c.String(),
                        Playlists_Id = c.Int(),
                        SavedSongs_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.PlaylistsModels", t => t.Playlists_Id)
                .ForeignKey("dbo.SavedSongsModels", t => t.SavedSongs_Id)
                .Index(t => t.Playlists_Id)
                .Index(t => t.SavedSongs_Id);
            
            AddColumn("dbo.SongsModels", "genreId", c => c.Int(nullable: false));
            AddColumn("dbo.SongsModels", "Genres_Id", c => c.Int());
            CreateIndex("dbo.SongsModels", "Genres_Id");
            AddForeignKey("dbo.SongsModels", "Genres_Id", "dbo.GenresModels", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SongsModels", "Genres_Id", "dbo.GenresModels");
            DropForeignKey("dbo.SavedSongsModels", "SavedSongs_Id", "dbo.SavedSongsModels");
            DropForeignKey("dbo.SavedSongsModels", "Playlists_Id", "dbo.PlaylistsModels");
            DropIndex("dbo.SongsModels", new[] { "Genres_Id" });
            DropIndex("dbo.SavedSongsModels", new[] { "SavedSongs_Id" });
            DropIndex("dbo.SavedSongsModels", new[] { "Playlists_Id" });
            DropColumn("dbo.SongsModels", "Genres_Id");
            DropColumn("dbo.SongsModels", "genreId");
            DropTable("dbo.SavedSongsModels");
            DropTable("dbo.PlaylistsModels");
        }
    }
}
