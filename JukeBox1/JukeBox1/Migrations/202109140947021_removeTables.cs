namespace JukeBox1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SavedSongsModels", "playlistId", "dbo.PlaylistsModels");
            DropIndex("dbo.SavedSongsModels", new[] { "playlistId" });
            DropTable("dbo.SavedSongsModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SavedSongsModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        playlistId = c.Int(nullable: false),
                        songIds = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateIndex("dbo.SavedSongsModels", "playlistId");
            AddForeignKey("dbo.SavedSongsModels", "playlistId", "dbo.PlaylistsModels", "id", cascadeDelete: true);
        }
    }
}
