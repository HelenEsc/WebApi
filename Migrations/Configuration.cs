namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApi.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApi.Models.WebApiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WebApi.Models.WebApiContext";
        }

        protected override void Seed(WebApi.Models.WebApiContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.Books.AddOrUpdate(x => x.id,
                new Book()
                {
                    id = 1,
                    title = "Book 1",
                    description = "book 1 description",
                    pageCount = 1000,
                    excerpt = "book 1 excerpt",
                    publishDate = "2021-04-11T15:09:52.7259064+00:00"
                },
                new Book()
                {
                    id = 2,
                    title = "Book 2",
                    description = "book 2 description",
                    pageCount = 1000,
                    excerpt = "book 2 excerpt",
                    publishDate = "2021-04-11T15:09:52.7259064+00:00"
                },
                new Book()
                {
                    id = 3,
                    title = "Book 3",
                    description = "book 3 description",
                    pageCount = 1000,
                    excerpt = "book 3 excerpt",
                    publishDate = "2021-04-11T15:09:52.7259064+00:00"
                }
                );
        }
    }
}
