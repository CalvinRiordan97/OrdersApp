namespace OrdersApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCustomers1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Customers (Fname, Lname, Address, Phone) VALUES ('Sarah', 'Brooks', '456st', 222222)");
            Sql("INSERT INTO Customers (Fname, Lname, Address, Phone) VALUES ('Timmy', 'Tomson', '789st', 333333)");
        }
        
        public override void Down()
        {
        }
    }
}
