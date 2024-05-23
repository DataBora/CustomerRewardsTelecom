using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerRewardsTelecom.Migrations
{
    /// <inheritdoc />
    public partial class AddedAgendItToCustomersAndDateTimeToRewards : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Rewards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AgentId",
                table: "Customers",
                column: "AgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Agents_AgentId",
                table: "Customers",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Agents_AgentId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_AgentId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Rewards");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Customers");
        }
    }
}
