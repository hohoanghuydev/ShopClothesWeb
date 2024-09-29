namespace HoHoangHuy_WebShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DonHangs",
                c => new
                    {
                        MaDonHang = c.Int(nullable: false, identity: true),
                        MaSanPham = c.Int(nullable: false),
                        KichThuoc = c.String(),
                        SoLuong = c.Int(nullable: false),
                        TongTien = c.Int(nullable: false),
                        NgayDat = c.DateTime(nullable: false),
                        TrangThaiThanhToan = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaDonHang)
                .ForeignKey("dbo.SanPhams", t => t.MaSanPham, cascadeDelete: true)
                .Index(t => t.MaSanPham);
            
            CreateTable(
                "dbo.SanPhams",
                c => new
                    {
                        MaSanPham = c.Int(nullable: false, identity: true),
                        TenSanPham = c.String(nullable: false),
                        Gia = c.Int(nullable: false),
                        MoTa = c.String(nullable: false),
                        HinhAnh = c.String(),
                        MaLoaiSP = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaSanPham)
                .ForeignKey("dbo.LoaiSanPhams", t => t.MaLoaiSP, cascadeDelete: true)
                .Index(t => t.MaLoaiSP);
            
            CreateTable(
                "dbo.LoaiSanPhams",
                c => new
                    {
                        MaLoaiSP = c.Int(nullable: false, identity: true),
                        TenLoaiSP = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MaLoaiSP);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DonHangs", "MaSanPham", "dbo.SanPhams");
            DropForeignKey("dbo.SanPhams", "MaLoaiSP", "dbo.LoaiSanPhams");
            DropIndex("dbo.SanPhams", new[] { "MaLoaiSP" });
            DropIndex("dbo.DonHangs", new[] { "MaSanPham" });
            DropTable("dbo.LoaiSanPhams");
            DropTable("dbo.SanPhams");
            DropTable("dbo.DonHangs");
        }
    }
}
