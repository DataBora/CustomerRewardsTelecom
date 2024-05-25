using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerRewardsTelecom.Migrations
{
    /// <inheritdoc />
    public partial class AdjustingCustomersForSOAPTwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.AddColumn<string>(
                name: "HomeCity",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HomeState",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HomeStreet",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HomeZip",
                table: "Customers",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OfficeCity",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OfficeState",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OfficeStreet",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OfficeZip",
                table: "Customers",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HomeCity",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "HomeState",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "HomeStreet",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "HomeZip",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "OfficeCity",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "OfficeState",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "OfficeStreet",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "OfficeZip",
                table: "Customers");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                });
        }
    }
}
