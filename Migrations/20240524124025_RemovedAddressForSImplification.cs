using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerRewardsTelecom.Migrations
{
    /// <inheritdoc />
    public partial class RemovedAddressForSImplification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Addresses_HomeAddressId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Rewards_Agents_AgentId",
                table: "Rewards");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Rewards_AgentId",
                table: "Rewards");

            migrationBuilder.DropIndex(
                name: "IX_Customers_HomeAddressId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Rewards");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "HomeAddressId",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Zip",
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
                name: "City",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Zip",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "Rewards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HomeAddressId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_AgentId",
                table: "Rewards",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_HomeAddressId",
                table: "Customers",
                column: "HomeAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Addresses_HomeAddressId",
                table: "Customers",
                column: "HomeAddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rewards_Agents_AgentId",
                table: "Rewards",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
