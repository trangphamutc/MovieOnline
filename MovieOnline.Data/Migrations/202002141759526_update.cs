namespace MovieOnline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Errors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        StackTrace = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Genres", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Movies", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Status");
            DropColumn("dbo.Movies", "CreatedDate");
            DropColumn("dbo.Genres", "Status");
            DropTable("dbo.Errors");
        }
    }
}
