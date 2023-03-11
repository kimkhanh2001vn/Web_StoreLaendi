namespace LaendiStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Value = c.String(maxLength: 100),
                        Alias = c.String(nullable: false, maxLength: 256),
                        Description = c.String(maxLength: 256),
                        ParentID = c.Int(),
                        DisplayOrder = c.Int(),
                        HomeOrder = c.Int(),
                        Image = c.String(maxLength: 256),
                        HomeFlag = c.Boolean(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        MetaKeyword = c.String(maxLength: 256),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Alias = c.String(nullable: false, maxLength: 256),
                        CategoryID = c.Int(nullable: false),
                        Image = c.String(maxLength: 256),
                        MoreImage = c.String(maxLength: 256),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PromotionPrice = c.Decimal(precision: 18, scale: 2),
                        Warranty = c.Int(),
                        Description = c.String(maxLength: 256),
                        Content = c.String(maxLength: 256),
                        ViewCount = c.Int(nullable: false),
                        Tags = c.String(maxLength: 256),
                        Code = c.String(maxLength: 256),
                        Brand = c.String(maxLength: 256),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        MetaKeyword = c.String(maxLength: 256),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Category", t => t.CategoryID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.OrderDetail",
                c => new
                    {
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ColorId = c.Int(),
                        SizeId = c.Int(),
                    })
                .PrimaryKey(t => new { t.OrderID, t.ProductID })
                .ForeignKey("dbo.Order", t => t.OrderID)
                .ForeignKey("dbo.Product", t => t.ProductID)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false, maxLength: 256),
                        CustomerAddress = c.String(nullable: false, maxLength: 256),
                        CustomerEmail = c.String(nullable: false, maxLength: 256),
                        CustomerMobile = c.String(maxLength: 256),
                        PaymentMethod = c.String(maxLength: 256),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        PaymentStatus = c.String(maxLength: 256),
                        Status = c.Int(nullable: false),
                        ShipperID = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .ForeignKey("dbo.Shippers", t => t.ShipperID)
                .Index(t => t.ShipperID)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 256),
                        PassWord = c.String(maxLength: 256),
                        CustomerName = c.String(maxLength: 256),
                        CustomerAddress = c.String(maxLength: 256),
                        CustomerWork = c.String(maxLength: 256),
                        Description = c.String(maxLength: 256),
                        Status = c.Boolean(),
                        CustomerEmail = c.String(maxLength: 256),
                        NumberPhone = c.Int(),
                        CreateDate = c.DateTime(),
                        Avata = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Shippers",
                c => new
                    {
                        ShipperID = c.Int(nullable: false, identity: true),
                        ShipperName = c.String(maxLength: 256),
                        Company = c.String(maxLength: 256),
                        NumberPhone = c.Double(nullable: false),
                        StoreID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShipperID)
                .ForeignKey("dbo.Stores", t => t.StoreID)
                .Index(t => t.StoreID);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoreID = c.Int(nullable: false, identity: true),
                        StoreName = c.String(maxLength: 256),
                        Address = c.String(maxLength: 256),
                        Code = c.String(maxLength: 50),
                        CreateDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StoreID)
                .ForeignKey("dbo.User", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 256),
                        PassWord = c.String(maxLength: 256),
                        Role = c.String(maxLength: 256),
                        Name = c.String(maxLength: 256),
                        Email = c.String(maxLength: 250),
                        NumberPhone = c.Double(nullable: false),
                        Address = c.String(maxLength: 256),
                        Nation = c.String(maxLength: 256),
                        MyWork = c.String(maxLength: 256),
                        Status = c.Boolean(),
                        Description = c.String(maxLength: 256),
                        Images = c.String(),
                        CreateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "CategoryID", "dbo.Category");
            DropForeignKey("dbo.OrderDetail", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Stores", "UserID", "dbo.User");
            DropForeignKey("dbo.Shippers", "StoreID", "dbo.Stores");
            DropForeignKey("dbo.Order", "ShipperID", "dbo.Shippers");
            DropForeignKey("dbo.OrderDetail", "OrderID", "dbo.Order");
            DropForeignKey("dbo.Order", "CustomerId", "dbo.Customer");
            DropIndex("dbo.Stores", new[] { "UserID" });
            DropIndex("dbo.Shippers", new[] { "StoreID" });
            DropIndex("dbo.Order", new[] { "CustomerId" });
            DropIndex("dbo.Order", new[] { "ShipperID" });
            DropIndex("dbo.OrderDetail", new[] { "ProductID" });
            DropIndex("dbo.OrderDetail", new[] { "OrderID" });
            DropIndex("dbo.Product", new[] { "CategoryID" });
            DropTable("dbo.User");
            DropTable("dbo.Stores");
            DropTable("dbo.Shippers");
            DropTable("dbo.Customer");
            DropTable("dbo.Order");
            DropTable("dbo.OrderDetail");
            DropTable("dbo.Product");
            DropTable("dbo.Category");
        }
    }
}
