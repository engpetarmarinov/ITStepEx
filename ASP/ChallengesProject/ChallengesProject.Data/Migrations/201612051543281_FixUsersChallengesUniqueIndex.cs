namespace ChallengesProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixUsersChallengesUniqueIndex : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.UsersChallenges", new[] { "ChallengeId" });
            DropIndex("dbo.UsersChallenges", "UQ_UsersChallenges_FromToUserId");
            CreateIndex("dbo.UsersChallenges", new[] { "ChallengeId", "FromUserId", "ToUserId" }, unique: true, name: "UQ_UsersChallenges_FromToUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.UsersChallenges", "UQ_UsersChallenges_FromToUserId");
            CreateIndex("dbo.UsersChallenges", new[] { "FromUserId", "ToUserId" }, unique: true, name: "UQ_UsersChallenges_FromToUserId");
            CreateIndex("dbo.UsersChallenges", "ChallengeId");
        }
    }
}
