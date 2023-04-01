using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class KeyUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeAllots_People_Personid",
                table: "TimeAllots");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeAllots_Tasks_ActivityTaskid",
                table: "TimeAllots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeAllots",
                table: "TimeAllots");

            migrationBuilder.DropIndex(
                name: "IX_TimeAllots_ActivityTaskid",
                table: "TimeAllots");

            migrationBuilder.DropIndex(
                name: "IX_TimeAllots_Personid",
                table: "TimeAllots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.DropColumn(
                name: "ActivityTaskid",
                table: "TimeAllots");

            migrationBuilder.DropColumn(
                name: "Personid",
                table: "TimeAllots");

            migrationBuilder.DropColumn(
                name: "taskId",
                table: "TimeAllots");

            migrationBuilder.RenameTable(
                name: "TimeAllots",
                newName: "TimeAlloted");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "ActivityTask");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "Person");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "TimeAlloted",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeAlloted",
                table: "TimeAlloted",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivityTask",
                table: "ActivityTask",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeAlloted_ActivityTask_id",
                table: "TimeAlloted");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeAlloted_Person_id",
                table: "TimeAlloted");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeAlloted",
                table: "TimeAlloted");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivityTask",
                table: "ActivityTask");

            migrationBuilder.RenameTable(
                name: "TimeAlloted",
                newName: "TimeAllots");

            migrationBuilder.RenameTable(
                name: "Person",
                newName: "People");

            migrationBuilder.RenameTable(
                name: "ActivityTask",
                newName: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "TimeAllots",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "ActivityTaskid",
                table: "TimeAllots",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Personid",
                table: "TimeAllots",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "taskId",
                table: "TimeAllots",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeAllots",
                table: "TimeAllots",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_TimeAllots_ActivityTaskid",
                table: "TimeAllots",
                column: "ActivityTaskid");

            migrationBuilder.CreateIndex(
                name: "IX_TimeAllots_Personid",
                table: "TimeAllots",
                column: "Personid");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeAllots_People_Personid",
                table: "TimeAllots",
                column: "Personid",
                principalTable: "People",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeAllots_Tasks_ActivityTaskid",
                table: "TimeAllots",
                column: "ActivityTaskid",
                principalTable: "Tasks",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
