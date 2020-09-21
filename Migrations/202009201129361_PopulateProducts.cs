namespace OrdersApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateProducts : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Products (Name, Price, Description, CreationDate, ExpiredDate) VALUES ('Table', 30, 'Wood table', '20/1/20', '20/1/21')");
            Sql("INSERT INTO Products (Name, Price, Description, CreationDate, ExpiredDate) VALUES ('Chair', 20, 'Wood chair', '20/1/20', '20/1/22')");
            Sql("INSERT INTO Products (Name, Price, Description, CreationDate, ExpiredDate) VALUES ('TV', 100, 'HD tv', '20/1/20', '20/1/23')");

           
        }
        
        public override void Down()
        {
        }
    }
}
