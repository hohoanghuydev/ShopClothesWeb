namespace HoHoangHuy_WebShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addKhachHang : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonHangs", "KhachHang", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DonHangs", "KhachHang");
        }
    }
}
