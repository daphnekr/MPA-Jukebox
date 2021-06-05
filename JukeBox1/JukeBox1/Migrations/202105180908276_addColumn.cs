namespace JukeBox1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SongsModels", "songName", c => c.String());
            AddColumn("dbo.SongsModels", "artist", c => c.String());
            DropColumn("dbo.SongsModels", "name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SongsModels", "name", c => c.String());
            DropColumn("dbo.SongsModels", "artist");
            DropColumn("dbo.SongsModels", "songName");
        }
    }
}
