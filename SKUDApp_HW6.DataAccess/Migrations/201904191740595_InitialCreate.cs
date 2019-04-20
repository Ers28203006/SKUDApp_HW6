namespace SKUDApp_HW6.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Controllers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        PassportNumber = c.String(),
                        CardNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentificationCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CardNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InputReaders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CardNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        PassportNumber = c.String(),
                        EntryTime = c.String(),
                        OutputTime = c.String(),
                        PurposeVisit = c.String(),
                        CardNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OutputReaders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CardNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        public override void Down()
        {
            DropTable("dbo.OutputReaders");
            DropTable("dbo.Logs");
            DropTable("dbo.InputReaders");
            DropTable("dbo.IdentificationCards");
            DropTable("dbo.Controllers");
        }
    }
}
