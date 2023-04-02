using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityTask",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    type = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityTask", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    firstname = table.Column<string>(type: "TEXT", nullable: false),
                    lastname = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TimeAlloted",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    start = table.Column<DateTime>(type: "TEXT", nullable: false),
                    end = table.Column<DateTime>(type: "TEXT", nullable: false),
                    elapsedTime = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    amount = table.Column<string>(type: "TEXT", nullable: true),
                    ActivityTaskid = table.Column<int>(type: "INTEGER", nullable: false),
                    Personid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeAlloted", x => x.id);
                    table.ForeignKey(
                        name: "FK_TimeAlloted_ActivityTask_ActivityTaskid",
                        column: x => x.ActivityTaskid,
                        principalTable: "ActivityTask",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeAlloted_Person_Personid",
                        column: x => x.Personid,
                        principalTable: "Person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ActivityTask",
                columns: new[] { "id", "type" },
                values: new object[,]
                {
                    { 1, "ClaimScrubber" },
                    { 2, "Correspondence" },
                    { 3, "CBR" },
                    { 4, "Education" },
                    { 5, "Emails" },
                    { 6, "ErrorChecks" },
                    { 7, "FollowDenial" },
                    { 8, "RmindersBillingInqu" },
                    { 9, "Meetings" },
                    { 10, "Reports" },
                    { 11, "Rycan" },
                    { 12, "SpecialProjects" },
                    { 13, "Training" },
                    { 14, "SystemIssues" },
                    { 15, "Break" },
                    { 16, "Other" }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "id", "firstname", "lastname" },
                values: new object[] { 1, "Justin", "Boundy" });

            migrationBuilder.CreateIndex(
                name: "IX_TimeAlloted_ActivityTaskid",
                table: "TimeAlloted",
                column: "ActivityTaskid");

            migrationBuilder.CreateIndex(
                name: "IX_TimeAlloted_Personid",
                table: "TimeAlloted",
                column: "Personid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeAlloted");

            migrationBuilder.DropTable(
                name: "ActivityTask");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
