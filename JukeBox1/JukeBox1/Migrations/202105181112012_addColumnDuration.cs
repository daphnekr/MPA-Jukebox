namespace JukeBox1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumnDuration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SongsModels", "duration", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SongsModels", "duration");
        }
    }
}
