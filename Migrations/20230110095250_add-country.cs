using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class addcountry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_Country_CountryId1",
                table: "City");

            migrationBuilder.DropIndex(
                name: "IX_City_CountryId1",
                table: "City");

            migrationBuilder.DropColumn(
                name: "CountryId1",
                table: "City");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "City",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryId",
                table: "City",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_City_Country_CountryId",
                table: "City",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_Country_CountryId",
                table: "City");

            migrationBuilder.DropIndex(
                name: "IX_City_CountryId",
                table: "City");

            migrationBuilder.AlterColumn<double>(
                name: "CountryId",
                table: "City",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CountryId1",
                table: "City",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryId1",
                table: "City",
                column: "CountryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_City_Country_CountryId1",
                table: "City",
                column: "CountryId1",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
