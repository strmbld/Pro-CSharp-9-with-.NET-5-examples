using Microsoft.EntityFrameworkCore.Migrations;
using AutoLot.Dal.EfStructures;


namespace AutoLot.Dal.EfStructures.Migrations
{
    public partial class SQL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            MigrationsHelper.CreateStoredProcedure(migrationBuilder);
            MigrationsHelper.CreateCustomerOrderView(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            MigrationsHelper.DropStoredProcedure(migrationBuilder);
            MigrationsHelper.DropCustomerOrderView(migrationBuilder);
        }
    }
}
