namespace CRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Address2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Addresses", "AddressGlobalName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "AddressGlobalName", c => c.String());
        }
    }
}
