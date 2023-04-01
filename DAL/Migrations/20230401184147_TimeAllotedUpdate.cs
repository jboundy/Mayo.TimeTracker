using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class TimeAllotedUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeAllots_People_Personid",
                table: "TimeAllots");

            migrationBuilder.AlterColumn<int>(
                name: "Personid",
                table: "TimeAllots",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeAllots_People_Personid",
                table: "TimeAllots",
                column: "Personid",
                principalTable: "People",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeAllots_People_Personid",
                table: "TimeAllots");

            migrationBuilder.AlterColumn<int>(
                name: "Personid",
                table: "TimeAllots",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeAllots_People_Personid",
                table: "TimeAllots",
                column: "Personid",
                principalTable: "People",
                principalColumn: "id");
        }
    }
}
