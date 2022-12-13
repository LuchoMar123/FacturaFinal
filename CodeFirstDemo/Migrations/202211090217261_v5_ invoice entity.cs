namespace CodeFirstDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v5_invoiceentity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InvoiceDetails",
                c => new
                    {
                        InvoiceDetailID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        InvoiceNumber = c.String(),
                    })
                .PrimaryKey(t => t.InvoiceDetailID);
            
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        SellerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        InvoiceDetail_InvoiceDetailID = c.Int(),
                    })
                .PrimaryKey(t => t.SellerID)
                .ForeignKey("dbo.InvoiceDetails", t => t.InvoiceDetail_InvoiceDetailID)
                .Index(t => t.InvoiceDetail_InvoiceDetailID);
            
            AddColumn("dbo.Customers", "InvoiceDetail_InvoiceDetailID", c => c.Int());
            AddColumn("dbo.Invoices", "InvoiceDetail_InvoiceDetailID", c => c.Int());
            AddColumn("dbo.Products", "InvoiceDetail_InvoiceDetailID", c => c.Int());
            CreateIndex("dbo.Customers", "InvoiceDetail_InvoiceDetailID");
            CreateIndex("dbo.Invoices", "InvoiceDetail_InvoiceDetailID");
            CreateIndex("dbo.Products", "InvoiceDetail_InvoiceDetailID");
            AddForeignKey("dbo.Customers", "InvoiceDetail_InvoiceDetailID", "dbo.InvoiceDetails", "InvoiceDetailID");
            AddForeignKey("dbo.Invoices", "InvoiceDetail_InvoiceDetailID", "dbo.InvoiceDetails", "InvoiceDetailID");
            AddForeignKey("dbo.Products", "InvoiceDetail_InvoiceDetailID", "dbo.InvoiceDetails", "InvoiceDetailID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sellers", "InvoiceDetail_InvoiceDetailID", "dbo.InvoiceDetails");
            DropForeignKey("dbo.Products", "InvoiceDetail_InvoiceDetailID", "dbo.InvoiceDetails");
            DropForeignKey("dbo.Invoices", "InvoiceDetail_InvoiceDetailID", "dbo.InvoiceDetails");
            DropForeignKey("dbo.Customers", "InvoiceDetail_InvoiceDetailID", "dbo.InvoiceDetails");
            DropIndex("dbo.Sellers", new[] { "InvoiceDetail_InvoiceDetailID" });
            DropIndex("dbo.Products", new[] { "InvoiceDetail_InvoiceDetailID" });
            DropIndex("dbo.Invoices", new[] { "InvoiceDetail_InvoiceDetailID" });
            DropIndex("dbo.Customers", new[] { "InvoiceDetail_InvoiceDetailID" });
            DropColumn("dbo.Products", "InvoiceDetail_InvoiceDetailID");
            DropColumn("dbo.Invoices", "InvoiceDetail_InvoiceDetailID");
            DropColumn("dbo.Customers", "InvoiceDetail_InvoiceDetailID");
            DropTable("dbo.Sellers");
            DropTable("dbo.InvoiceDetails");
        }
    }
}
