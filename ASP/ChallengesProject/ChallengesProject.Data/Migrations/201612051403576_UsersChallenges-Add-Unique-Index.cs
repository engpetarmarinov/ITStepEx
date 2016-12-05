namespace ChallengesProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsersChallengesAddUniqueIndex : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.UsersChallenges", new[] { "FromUserId" });
            DropIndex("dbo.UsersChallenges", new[] { "ToUserId" });
            CreateIndex("dbo.UsersChallenges", new[] { "FromUserId", "ToUserId" }, unique: true, name: "UQ_UsersChallenges_FromToUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.UsersChallenges", "UQ_UsersChallenges_FromToUserId");
            CreateIndex("dbo.UsersChallenges", "ToUserId");
            CreateIndex("dbo.UsersChallenges", "FromUserId");
        }
    }
}
