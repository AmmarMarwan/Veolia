namespace Veolia.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FormControlConform", "wc", c => c.String());
            AlterColumn("dbo.FormControlConform", "anomaliesConstatees", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FormControlConform", "anomaliesConstatees", c => c.DateTime());
            AlterColumn("dbo.FormControlConform", "wc", c => c.Int(nullable: false));
        }
    }
}
