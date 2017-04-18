namespace Veolia.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ini : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FormControlConform", "dateControle", c => c.DateTime());
            AlterColumn("dbo.FormControlConform", "anomaliesConstatees", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FormControlConform", "anomaliesConstatees", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FormControlConform", "dateControle", c => c.DateTime(nullable: false));
        }
    }
}
