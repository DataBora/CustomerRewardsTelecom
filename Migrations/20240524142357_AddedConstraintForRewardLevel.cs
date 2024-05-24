using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerRewardsTelecom.Migrations
{
    /// <inheritdoc />
    public partial class AddedConstraintForRewardLevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Rewards",
                newName: "RewardLevel");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Reward_Level",
                table: "Rewards",
                sql: "[RewardLevel] IN ('Bronze', 'Silver', 'Gold')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Reward_Level",
                table: "Rewards");

            migrationBuilder.RenameColumn(
                name: "RewardLevel",
                table: "Rewards",
                newName: "Description");
        }
    }
}
