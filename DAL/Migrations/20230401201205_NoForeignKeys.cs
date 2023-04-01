using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class NoForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeAlloted_ActivityTask_id",
                table: "TimeAlloted");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeAlloted_Person_id",
                table: "TimeAlloted");

            migrationBuilder.AddColumn<int>(
                name: "ActivityTaskid",
                table: "TimeAlloted",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Personid",
                table: "TimeAlloted",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TimeAlloted_ActivityTaskid",
                table: "TimeAlloted",
                column: "ActivityTaskid");

            migrationBuilder.CreateIndex(
                name: "IX_TimeAlloted_Personid",
                table: "TimeAlloted",
                column: "Personid");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeAlloted_ActivityTask_ActivityTaskid",
                table: "TimeAlloted",
                column: "ActivityTaskid",
                principalTable: "ActivityTask",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeAlloted_Person_Personid",
                table: "TimeAlloted",
                column: "Personid",
                principalTable: "Person",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeAlloted_ActivityTask_ActivityTaskid",
                table: "TimeAlloted");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeAlloted_Person_Personid",
                table: "TimeAlloted");

            migrationBuilder.DropIndex(
                name: "IX_TimeAlloted_ActivityTaskid",
                table: "TimeAlloted");

            migrationBuilder.DropIndex(
                name: "IX_TimeAlloted_Personid",
                table: "TimeAlloted");

            migrationBuilder.DropColumn(
                name: "ActivityTaskid",
                table: "TimeAlloted");

            migrationBuilder.DropColumn(
                name: "Personid",
                table: "TimeAlloted");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeAlloted_ActivityTask_id",
                table: "TimeAlloted",
                column: "id",
                principalTable: "ActivityTask",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeAlloted_Person_id",
                table: "TimeAlloted",
                column: "id",
                principalTable: "Person",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
