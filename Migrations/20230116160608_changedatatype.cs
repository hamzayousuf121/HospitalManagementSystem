using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class changedatatype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Branches_BranchId",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "BranchId",
                table: "Patients",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_BranchId",
                table: "Patients",
                newName: "IX_Patients_CityId");

            migrationBuilder.AlterColumn<string>(
                name: "HospitalMapCode",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Cities_CityId",
                table: "Patients",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Cities_CityId",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Patients",
                newName: "BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_CityId",
                table: "Patients",
                newName: "IX_Patients_BranchId");

            migrationBuilder.AlterColumn<double>(
                name: "HospitalMapCode",
                table: "Contacts",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Branches_BranchId",
                table: "Patients",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
