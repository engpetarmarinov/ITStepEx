namespace ChallengesProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsersChallengesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UsersChallenges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChallengeId = c.Int(nullable: false),
                        FromUserId = c.String(maxLength: 128),
                        ToUserId = c.String(maxLength: 128),
                        Status = c.Int(nullable: false),
                        StartedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Challenges", t => t.ChallengeId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.FromUserId)
                .ForeignKey("dbo.AspNetUsers", t => t.ToUserId)
                .Index(t => t.ChallengeId)
                .Index(t => t.FromUserId)
                .Index(t => t.ToUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersChallenges", "ToUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UsersChallenges", "FromUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UsersChallenges", "ChallengeId", "dbo.Challenges");
            DropIndex("dbo.UsersChallenges", new[] { "ToUserId" });
            DropIndex("dbo.UsersChallenges", new[] { "FromUserId" });
            DropIndex("dbo.UsersChallenges", new[] { "ChallengeId" });
            DropTable("dbo.UsersChallenges");
        }
    }
}
