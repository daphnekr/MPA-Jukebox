namespace JukeBox1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class revertLastChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PlaylistsModels", "playlistName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PlaylistsModels", "playlistName", c => c.String(maxLength: 20));
        }
    }
}
