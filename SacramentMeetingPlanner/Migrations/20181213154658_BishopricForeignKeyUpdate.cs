using Microsoft.EntityFrameworkCore.Migrations;

namespace SacramentMeetingPlanner.Migrations
{
    public partial class BishopricForeignKeyUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_Planner_BishopricId",
                table: "Planner",
                column: "BishopricId");

            migrationBuilder.AddForeignKey(
                name: "FK_Planner_Bishopric_BishopricId",
                table: "Planner",
                column: "BishopricId",
                principalTable: "Bishopric",
                principalColumn: "BishopricId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planner_Bishopric_BishopricId",
                table: "Planner");

            migrationBuilder.DropIndex(
                name: "IX_Planner_BishopricId",
                table: "Planner");

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
    }
}
