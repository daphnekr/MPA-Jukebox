namespace JukeBox1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addForeignKeysSavedSongs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SavedSongsModels", "SavedSongs_Id", "dbo.SavedSongsModels");
            DropForeignKey("dbo.SavedSongsModels", "Playlists_Id", "dbo.PlaylistsModels");
            DropIndex("dbo.SavedSongsModels", new[] { "Playlists_Id" });
            DropIndex("dbo.SavedSongsModels", new[] { "SavedSongs_Id" });
            RenameColumn(table: "dbo.SavedSongsModels", name: "Playlists_Id", newName: "playlistId");
            AddColumn("dbo.SavedSongsModels", "songIds", c => c.String());
            AlterColumn("dbo.SavedSongsModels", "playlistId", c => c.Int(nullable: false));
            CreateIndex("dbo.SavedSongsModels", "playlistId");
            AddForeignKey("dbo.SavedSongsModels", "playlistId", "dbo.PlaylistsModels", "id", cascadeDelete: true);
            DropColumn("dbo.SavedSongsModels", "SavedSongs_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SavedSongsModels", "SavedSongs_Id", c => c.Int());
            DropForeignKey("dbo.SavedSongsModels", "playlistId", "dbo.PlaylistsModels");
            DropIndex("dbo.SavedSongsModels", new[] { "playlistId" });
            AlterColumn("dbo.SavedSongsModels", "playlistId", c => c.Int());
            DropColumn("dbo.SavedSongsModels", "songIds");
            RenameColumn(table: "dbo.SavedSongsModels", name: "playlistId", newName: "Playlists_Id");
            CreateIndex("dbo.SavedSongsModels", "SavedSongs_Id");
            CreateIndex("dbo.SavedSongsModels", "Playlists_Id");
            AddForeignKey("dbo.SavedSongsModels", "Playlists_Id", "dbo.PlaylistsModels", "id");
            AddForeignKey("dbo.SavedSongsModels", "SavedSongs_Id", "dbo.SavedSongsModels", "id");
        }
    }
}
