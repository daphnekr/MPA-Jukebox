namespace JukeBox1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addForeignKeySongs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SongsModels", "Genres_Id", "dbo.GenresModels");
            DropIndex("dbo.SongsModels", new[] { "Genres_Id" });
            RenameColumn(table: "dbo.SongsModels", name: "Genres_Id", newName: "genreId");
            AlterColumn("dbo.SongsModels", "genreId", c => c.Int(nullable: false));
            CreateIndex("dbo.SongsModels", "genreId");
            AddForeignKey("dbo.SongsModels", "genreId", "dbo.GenresModels", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SongsModels", "genreId", "dbo.GenresModels");
            DropIndex("dbo.SongsModels", new[] { "genreId" });
            AlterColumn("dbo.SongsModels", "genreId", c => c.Int());
            RenameColumn(table: "dbo.SongsModels", name: "genreId", newName: "Genres_Id");
            CreateIndex("dbo.SongsModels", "Genres_Id");
            AddForeignKey("dbo.SongsModels", "Genres_Id", "dbo.GenresModels", "id");
        }
    }
}
