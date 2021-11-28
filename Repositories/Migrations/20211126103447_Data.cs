using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Insert into Employees values 
                                ('Moustafa', 'Senior Backend Developer', 30),
                                ('Mahmoud','Senior Backend Developer', 30),
                                ('Tarek','Junior Backend Developer', 28),
                                ('Amr','UX Lead', 28)

                                insert into Brands values ('Toyota'), ('Nissan'), ('Mitsubishi'), ('Mercedes')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Delete from Employees; Delete from Brands; Delete from CardTypes");
        }
    }
}
