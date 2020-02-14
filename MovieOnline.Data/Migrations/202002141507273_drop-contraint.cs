namespace MovieOnline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropcontraint : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GenreMovies", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.GenreMovies", "MovieId", "dbo.Movies");
            DropIndex("dbo.GenreMovies", new[] { "GenreId" });
            DropIndex("dbo.GenreMovies", new[] { "MovieId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.GenreMovies", "MovieId");
            CreateIndex("dbo.GenreMovies", "GenreId");
            AddForeignKey("dbo.GenreMovies", "MovieId", "dbo.Movies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GenreMovies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
    }
}
