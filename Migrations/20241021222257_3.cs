using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibrary.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactPeople_MilitaryUnits_MilitaryUnitId",
                table: "ContactPeople");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactPeople",
                table: "ContactPeople");

            migrationBuilder.RenameTable(
                name: "ContactPeople",
                newName: "ContactPersons");

            migrationBuilder.RenameIndex(
                name: "IX_ContactPeople_MilitaryUnitId",
                table: "ContactPersons",
                newName: "IX_ContactPersons_MilitaryUnitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactPersons",
                table: "ContactPersons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactPersons_MilitaryUnits_MilitaryUnitId",
                table: "ContactPersons",
                column: "MilitaryUnitId",
                principalTable: "MilitaryUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactPersons_MilitaryUnits_MilitaryUnitId",
                table: "ContactPersons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactPersons",
                table: "ContactPersons");

            migrationBuilder.RenameTable(
                name: "ContactPersons",
                newName: "ContactPeople");

            migrationBuilder.RenameIndex(
                name: "IX_ContactPersons_MilitaryUnitId",
                table: "ContactPeople",
                newName: "IX_ContactPeople_MilitaryUnitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactPeople",
                table: "ContactPeople",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactPeople_MilitaryUnits_MilitaryUnitId",
                table: "ContactPeople",
                column: "MilitaryUnitId",
                principalTable: "MilitaryUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
