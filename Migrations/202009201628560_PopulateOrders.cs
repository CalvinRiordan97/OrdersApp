namespace OrdersApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateOrders : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Orders (CreationDate, ExpiredDate, Customer_Id, Product_Id) VALUES ('20/1/20', '20/1/21', 1, 3)");
            Sql("INSERT INTO Orders (CreationDate, ExpiredDate, Customer_Id, Product_Id) VALUES ('25/1/20', '26/1/20', 3, 2)");
        }
        
        public override void Down()
        {
        }
    }
}
