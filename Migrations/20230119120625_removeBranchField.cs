using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class removeBranchField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageSliders_Branches_BranchId",
                table: "ImageSliders");

            migrationBuilder.DropIndex(
                name: "IX_ImageSliders_BranchId",
                table: "ImageSliders");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "ImageSliders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "ImageSliders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ImageSliders_BranchId",
                table: "ImageSliders",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageSliders_Branches_BranchId",
                table: "ImageSliders",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
