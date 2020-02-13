namespace MovieOnline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateGenreMovie1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GenreMovies",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MovieId, t.GenreId })
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.GenreId)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameVietNamese = c.String(maxLength: 500),
                        Description = c.String(maxLength: 4000),
                        NameOriginal = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GenreMovies", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.GenreMovies", "GenreId", "dbo.Genres");
            DropIndex("dbo.GenreMovies", new[] { "MovieId" });
            DropIndex("dbo.GenreMovies", new[] { "GenreId" });
            DropTable("dbo.Movies");
            DropTable("dbo.Genres");
            DropTable("dbo.GenreMovies");
        }
    }
}
