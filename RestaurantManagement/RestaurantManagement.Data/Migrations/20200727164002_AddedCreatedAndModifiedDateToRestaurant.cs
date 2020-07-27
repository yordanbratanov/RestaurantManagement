using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantManagement.Data.Migrations
{
    public partial class AddedCreatedAndModifiedDateToRestaurant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Restaurants",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Restaurants",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Restaurants");
        }
    }
}
