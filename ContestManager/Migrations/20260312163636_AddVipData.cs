using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContestManager.Migrations
{
    /// <inheritdoc />
    public partial class AddVipData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Contests",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2026, 3, 13, 16, 36, 36, 31, DateTimeKind.Utc).AddTicks(9034), new DateTime(2026, 3, 12, 16, 36, 36, 31, DateTimeKind.Utc).AddTicks(9029) });

            migrationBuilder.InsertData(
                table: "Contests",
                columns: new[] { "Id", "AccessLevel", "EndTime", "Name", "StartTime" },
                values: new object[] { 102, "VIP", new DateTime(2026, 3, 13, 16, 36, 36, 31, DateTimeKind.Utc).AddTicks(9053), "Exclusive VIP Challenge", new DateTime(2026, 3, 12, 16, 36, 36, 31, DateTimeKind.Utc).AddTicks(9051) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Role", "Username" },
                values: new object[] { 2, "VIP", "VipUser" });

            migrationBuilder.CreateIndex(
                name: "IX_UserContests_ContestId",
                table: "UserContests",
                column: "ContestId");

            migrationBuilder.CreateIndex(
                name: "IX_UserContests_UserId",
                table: "UserContests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserContests_Contests_ContestId",
                table: "UserContests",
                column: "ContestId",
                principalTable: "Contests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserContests_Users_UserId",
                table: "UserContests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserContests_Contests_ContestId",
                table: "UserContests");

            migrationBuilder.DropForeignKey(
                name: "FK_UserContests_Users_UserId",
                table: "UserContests");

            migrationBuilder.DropIndex(
                name: "IX_UserContests_ContestId",
                table: "UserContests");

            migrationBuilder.DropIndex(
                name: "IX_UserContests_UserId",
                table: "UserContests");

            migrationBuilder.DeleteData(
                table: "Contests",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Contests",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2026, 3, 13, 13, 24, 51, 786, DateTimeKind.Utc).AddTicks(1260), new DateTime(2026, 3, 12, 13, 24, 51, 786, DateTimeKind.Utc).AddTicks(1258) });
        }
    }
}
