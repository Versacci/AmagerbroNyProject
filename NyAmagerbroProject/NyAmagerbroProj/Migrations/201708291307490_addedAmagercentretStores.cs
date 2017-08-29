namespace NyAmagerbroProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedAmagercentretStores : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AmagercentretClothes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Navn = c.String(nullable: false),
                        Addresse = c.String(nullable: false),
                        Åbningstider = c.String(nullable: false),
                        telefon = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AmagercentretElectronics",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Navn = c.String(nullable: false),
                        Addresse = c.String(nullable: false),
                        Åbningstider = c.String(nullable: false),
                        telefon = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AmagercentretFoods",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Navn = c.String(nullable: false),
                        Addresse = c.String(nullable: false),
                        Åbningstider = c.String(nullable: false),
                        telefon = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AmagercentretFoods");
            DropTable("dbo.AmagercentretElectronics");
            DropTable("dbo.AmagercentretClothes");
        }
    }
}
