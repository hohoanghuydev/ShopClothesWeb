namespace HoHoangHuy_WebShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editDataType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DonHangs", "KhachHang", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DonHangs", "KhachHang", c => c.Int(nullable: false));
        }
    }
}
