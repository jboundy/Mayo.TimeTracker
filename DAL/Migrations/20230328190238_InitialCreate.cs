using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    firstname = table.Column<string>(type: "TEXT", nullable: false),
                    lastname = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    type = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TimeAllots",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    start = table.Column<DateTime>(type: "TEXT", nullable: false),
                    elapsedTime = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    amount = table.Column<string>(type: "TEXT", nullable: true),
                    taskId = table.Column<int>(type: "INTEGER", nullable: false),
                    ActivityTaskid = table.Column<int>(type: "INTEGER", nullable: false),
                    Personid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeAllots", x => x.id);
                    table.ForeignKey(
                        name: "FK_TimeAllots_People_Personid",
                        column: x => x.Personid,
                        principalTable: "People",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_TimeAllots_Tasks_ActivityTaskid",
                        column: x => x.ActivityTaskid,
                        principalTable: "Tasks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeAllots_ActivityTaskid",
                table: "TimeAllots",
                column: "ActivityTaskid");

            migrationBuilder.CreateIndex(
                name: "IX_TimeAllots_Personid",
                table: "TimeAllots",
                column: "Personid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeAllots");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
