namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class for_primary_key_error : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Headings", "WriterId", "dbo.Writers");
            DropIndex("dbo.Headings", new[] { "WriterId" });
            AlterColumn("dbo.Headings", "WriterId", c => c.Int());
            CreateIndex("dbo.Headings", "WriterId");
            AddForeignKey("dbo.Headings", "WriterId", "dbo.Writers", "WriterId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Headings", "WriterId", "dbo.Writers");
            DropIndex("dbo.Headings", new[] { "WriterId" });
            AlterColumn("dbo.Headings", "WriterId", c => c.Int(nullable: false));
            CreateIndex("dbo.Headings", "WriterId");
            AddForeignKey("dbo.Headings", "WriterId", "dbo.Writers", "WriterId", cascadeDelete: true);
        }
    }
}
