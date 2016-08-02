namespace MapMyData.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataSet_FirstPass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DataPoints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StateId = c.Int(nullable: false),
                        Value = c.String(),
                        Color = c.String(),
                        MapDataSet_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .ForeignKey("dbo.MapDataSets", t => t.MapDataSet_Id)
                .Index(t => t.StateId)
                .Index(t => t.MapDataSet_Id);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MapDataSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        OwnerId = c.String(maxLength: 128),
                        IsPublic = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.OwnerId)
                .Index(t => t.OwnerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MapDataSets", "OwnerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.DataPoints", "MapDataSet_Id", "dbo.MapDataSets");
            DropForeignKey("dbo.DataPoints", "StateId", "dbo.States");
            DropIndex("dbo.MapDataSets", new[] { "OwnerId" });
            DropIndex("dbo.DataPoints", new[] { "MapDataSet_Id" });
            DropIndex("dbo.DataPoints", new[] { "StateId" });
            DropTable("dbo.MapDataSets");
            DropTable("dbo.States");
            DropTable("dbo.DataPoints");
        }
    }
}
