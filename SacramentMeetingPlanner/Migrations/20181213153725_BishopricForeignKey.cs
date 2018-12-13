using Microsoft.EntityFrameworkCore.Migrations;

namespace SacramentMeetingPlanner.Migrations
{
    public partial class BishopricForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Bishopric",
                table: "Planner",
                newName: "BishopricId");

            migrationBuilder.AddColumn<int>(
                name: "PlannerId",
                table: "Bishopric",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bishopric_PlannerId",
                table: "Bishopric",
                column: "PlannerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bishopric_Planner_PlannerId",
                table: "Bishopric",
                column: "PlannerId",
                principalTable: "Planner",
                principalColumn: "PlannerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bishopric_Planner_PlannerId",
                table: "Bishopric");

            migrationBuilder.DropIndex(
                name: "IX_Bishopric_PlannerId",
                table: "Bishopric");

            migrationBuilder.DropColumn(
                name: "PlannerId",
                table: "Bishopric");

            migrationBuilder.RenameColumn(
                name: "BishopricId",
                table: "Planner",
                newName: "Bishopric");
        }
    }
}
