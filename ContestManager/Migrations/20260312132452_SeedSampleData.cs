using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContestManager.Migrations
{
    /// <inheritdoc />
    public partial class SeedSampleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contests",
                columns: new[] { "Id", "AccessLevel", "EndTime", "Name", "StartTime" },
                values: new object[] { 101, "Normal", new DateTime(2026, 3, 13, 13, 24, 51, 786, DateTimeKind.Utc).AddTicks(1260), "Sample Math Contest", new DateTime(2026, 3, 12, 13, 24, 51, 786, DateTimeKind.Utc).AddTicks(1258) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Role", "Username" },
                values: new object[] { 1, "Normal", "TestUser" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "ContestId", "Text", "Type" },
                values: new object[,]
                {
                    { 1, 101, "What is 2+2?", "Single" },
                    { 2, 101, "Select all even numbers.", "Multi" },
                    { 3, 101, "The sky is blue. (True/False)", "TrueFalse" }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsCorrect", "QuestionId", "Text" },
                values: new object[,]
                {
                    { 1, false, 1, "3" },
                    { 2, false, 1, "5" },
                    { 3, true, 1, "4" },
                    { 4, false, 2, "1" },
                    { 7, true, 2, "2" },
                    { 8, true, 2, "4" },
                    { 10, false, 3, "False" },
                    { 11, true, 3, "True" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Contests",
                keyColumn: "Id",
                keyValue: 101);
        }
    }
}
