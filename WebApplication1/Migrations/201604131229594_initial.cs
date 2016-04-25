namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BuildModels", "HeroModel_ID", "dbo.HeroModels");
            DropIndex("dbo.BuildModels", new[] { "HeroModel_ID" });
            DropTable("dbo.BuildModels");
            DropTable("dbo.HeroModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.HeroModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        heroName = c.String(nullable: false),
                        primaryAttribute = c.Int(nullable: false),
                        ranged = c.Boolean(nullable: false),
                        BAT = c.Double(nullable: false),
                        baseAgi = c.Double(nullable: false),
                        baseStr = c.Double(nullable: false),
                        baseInt = c.Double(nullable: false),
                        AgiGain = c.Double(nullable: false),
                        StrGain = c.Double(nullable: false),
                        IntGain = c.Double(nullable: false),
                        baseSpeed = c.Double(nullable: false),
                        baseDamage = c.Double(nullable: false),
                        baseArmor = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BuildModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Hero = c.String(nullable: false),
                        heroID = c.Int(nullable: false),
                        Item1 = c.Int(nullable: false),
                        Item2 = c.Int(nullable: false),
                        Item3 = c.Int(nullable: false),
                        Item4 = c.Int(nullable: false),
                        Item5 = c.Int(nullable: false),
                        Item6 = c.Int(nullable: false),
                        MoonShardEaten = c.Boolean(nullable: false),
                        level = c.Int(nullable: false),
                        HeroModel_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.BuildModels", "HeroModel_ID");
            AddForeignKey("dbo.BuildModels", "HeroModel_ID", "dbo.HeroModels", "ID");
        }
    }
}
