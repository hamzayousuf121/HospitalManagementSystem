using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class removeAddressTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_AddressDetails_AddressDetailId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_AddressDetails_AddressDetailId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Branches_BranchId",
                table: "Schedules");

            migrationBuilder.DropTable(
                name: "AddressDetails");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_BranchId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Patients_AddressDetailId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_AddressDetailId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "AddressDetailId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "AddressDetailId",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "To",
                table: "Schedules",
                newName: "ClinicStartTime");

            migrationBuilder.RenameColumn(
                name: "From",
                table: "Schedules",
                newName: "ClinicEndTime");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Schedules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "ClinicStartTime",
                table: "Schedules",
                newName: "To");

            migrationBuilder.RenameColumn(
                name: "ClinicEndTime",
                table: "Schedules",
                newName: "From");

            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AddressDetailId",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AddressDetailId",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AddressDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false),
                    StreetNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressDetails_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AddressDetails_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_BranchId",
                table: "Schedules",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AddressDetailId",
                table: "Patients",
                column: "AddressDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_AddressDetailId",
                table: "Doctors",
                column: "AddressDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressDetails_CityId",
                table: "AddressDetails",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressDetails_UserId",
                table: "AddressDetails",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_AddressDetails_AddressDetailId",
                table: "Doctors",
                column: "AddressDetailId",
                principalTable: "AddressDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_AddressDetails_AddressDetailId",
                table: "Patients",
                column: "AddressDetailId",
                principalTable: "AddressDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Branches_BranchId",
                table: "Schedules",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
