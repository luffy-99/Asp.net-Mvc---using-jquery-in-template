namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editTableUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IdentityUserClaims", "UserId", "dbo.User");
            DropForeignKey("dbo.IdentityUserLogins", "User_Id", "dbo.User");
            DropForeignKey("dbo.IdentityUserRoles", "UserId", "dbo.User");
            DropIndex("dbo.IdentityUserClaims", new[] { "UserId" });
            DropIndex("dbo.IdentityUserLogins", new[] { "User_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "UserId" });
            DropPrimaryKey("dbo.User");
            AddColumn("dbo.User", "Name", c => c.String(maxLength: 50));
            AddColumn("dbo.User", "PassWord", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.User", "Position", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.User", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.User", "UserName", c => c.String(nullable: false, maxLength: 50));
            AddPrimaryKey("dbo.User", "ID");
            DropColumn("dbo.User", "FullName");
            DropColumn("dbo.User", "Address");
            DropColumn("dbo.User", "BirthDay");
            DropColumn("dbo.User", "Email");
            DropColumn("dbo.User", "EmailConfirmed");
            DropColumn("dbo.User", "PasswordHash");
            DropColumn("dbo.User", "SecurityStamp");
            DropColumn("dbo.User", "PhoneNumber");
            DropColumn("dbo.User", "PhoneNumberConfirmed");
            DropColumn("dbo.User", "TwoFactorEnabled");
            DropColumn("dbo.User", "LockoutEndDateUtc");
            DropColumn("dbo.User", "LockoutEnabled");
            DropColumn("dbo.User", "AccessFailedCount");
            DropColumn("dbo.IdentityUserLogins", "User_Id");
            DropTable("dbo.IdentityUserClaims");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.IdentityUserLogins", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.User", "AccessFailedCount", c => c.Int(nullable: false));
            AddColumn("dbo.User", "LockoutEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.User", "LockoutEndDateUtc", c => c.DateTime());
            AddColumn("dbo.User", "TwoFactorEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.User", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.User", "PhoneNumber", c => c.String());
            AddColumn("dbo.User", "SecurityStamp", c => c.String());
            AddColumn("dbo.User", "PasswordHash", c => c.String());
            AddColumn("dbo.User", "EmailConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.User", "Email", c => c.String());
            AddColumn("dbo.User", "BirthDay", c => c.DateTime());
            AddColumn("dbo.User", "Address", c => c.String(maxLength: 256));
            AddColumn("dbo.User", "FullName", c => c.String(maxLength: 256));
            DropPrimaryKey("dbo.User");
            AlterColumn("dbo.User", "UserName", c => c.String());
            AlterColumn("dbo.User", "ID", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.User", "Position");
            DropColumn("dbo.User", "PassWord");
            DropColumn("dbo.User", "Name");
            AddPrimaryKey("dbo.User", "Id");
            CreateIndex("dbo.IdentityUserRoles", "UserId");
            CreateIndex("dbo.IdentityUserLogins", "User_Id");
            CreateIndex("dbo.IdentityUserClaims", "UserId");
            AddForeignKey("dbo.IdentityUserRoles", "UserId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.IdentityUserLogins", "User_Id", "dbo.User", "Id");
            AddForeignKey("dbo.IdentityUserClaims", "UserId", "dbo.User", "Id");
        }
    }
}
