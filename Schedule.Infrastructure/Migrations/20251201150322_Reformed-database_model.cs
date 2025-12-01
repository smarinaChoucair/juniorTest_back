using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schedule.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Reformeddatabase_model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assignation");

            migrationBuilder.AlterColumn<string>(
                name: "DayName",
                table: "Days",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddColumn<int>(
                name: "AssignedMeal",
                table: "Days",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Days",
                keyColumn: "DayId",
                keyValue: 1,
                column: "AssignedMeal",
                value: null);

            migrationBuilder.UpdateData(
                table: "Days",
                keyColumn: "DayId",
                keyValue: 2,
                column: "AssignedMeal",
                value: null);

            migrationBuilder.UpdateData(
                table: "Days",
                keyColumn: "DayId",
                keyValue: 3,
                column: "AssignedMeal",
                value: null);

            migrationBuilder.UpdateData(
                table: "Days",
                keyColumn: "DayId",
                keyValue: 4,
                column: "AssignedMeal",
                value: null);

            migrationBuilder.UpdateData(
                table: "Days",
                keyColumn: "DayId",
                keyValue: 5,
                column: "AssignedMeal",
                value: null);

            migrationBuilder.UpdateData(
                table: "Days",
                keyColumn: "DayId",
                keyValue: 6,
                column: "AssignedMeal",
                value: null);

            migrationBuilder.UpdateData(
                table: "Days",
                keyColumn: "DayId",
                keyValue: 7,
                column: "AssignedMeal",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Days_AssignedMeal",
                table: "Days",
                column: "AssignedMeal");

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Meals_AssignedMeal",
                table: "Days",
                column: "AssignedMeal",
                principalTable: "Meals",
                principalColumn: "MealId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Days_Meals_AssignedMeal",
                table: "Days");

            migrationBuilder.DropIndex(
                name: "IX_Days_AssignedMeal",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "AssignedMeal",
                table: "Days");

            migrationBuilder.AlterColumn<string>(
                name: "DayName",
                table: "Days",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.CreateTable(
                name: "Assignation",
                columns: table => new
                {
                    AssignationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayId = table.Column<int>(type: "int", nullable: false),
                    MealId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignation", x => x.AssignationId);
                    table.ForeignKey(
                        name: "FK_Assignation_Days_DayId",
                        column: x => x.DayId,
                        principalTable: "Days",
                        principalColumn: "DayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assignation_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "MealId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignation_DayId",
                table: "Assignation",
                column: "DayId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignation_MealId",
                table: "Assignation",
                column: "MealId");
        }
    }
}
