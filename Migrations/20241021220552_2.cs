using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibrary.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactPersons_MilitaryUnits_MilitaryUnitId",
                table: "ContactPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageEntity_Volunteers_FromVolunteerId",
                table: "MessageEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageEntity_Volunteers_ToVolunteerId",
                table: "MessageEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_VolunteerOrganizationEntity_Organizations_OrganizationId",
                table: "VolunteerOrganizationEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_VolunteerOrganizationEntity_Volunteers_VolunteerId",
                table: "VolunteerOrganizationEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VolunteerOrganizationEntity",
                table: "VolunteerOrganizationEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageEntity",
                table: "MessageEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactPersons",
                table: "ContactPersons");

            migrationBuilder.RenameTable(
                name: "VolunteerOrganizationEntity",
                newName: "VolunteerOrganizations");

            migrationBuilder.RenameTable(
                name: "MessageEntity",
                newName: "Messages");

            migrationBuilder.RenameTable(
                name: "ContactPersons",
                newName: "ContactPeople");

            migrationBuilder.RenameIndex(
                name: "IX_VolunteerOrganizationEntity_OrganizationId",
                table: "VolunteerOrganizations",
                newName: "IX_VolunteerOrganizations_OrganizationId");

            migrationBuilder.RenameIndex(
                name: "IX_MessageEntity_ToVolunteerId",
                table: "Messages",
                newName: "IX_Messages_ToVolunteerId");

            migrationBuilder.RenameIndex(
                name: "IX_MessageEntity_FromVolunteerId",
                table: "Messages",
                newName: "IX_Messages_FromVolunteerId");

            migrationBuilder.RenameIndex(
                name: "IX_ContactPersons_MilitaryUnitId",
                table: "ContactPeople",
                newName: "IX_ContactPeople_MilitaryUnitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VolunteerOrganizations",
                table: "VolunteerOrganizations",
                columns: new[] { "VolunteerId", "OrganizationId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactPeople",
                table: "ContactPeople",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ContactPeople_MilitaryUnits_MilitaryUnitId",
                table: "ContactPeople",
                column: "MilitaryUnitId",
                principalTable: "MilitaryUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Volunteers_FromVolunteerId",
                table: "Messages",
                column: "FromVolunteerId",
                principalTable: "Volunteers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Volunteers_ToVolunteerId",
                table: "Messages",
                column: "ToVolunteerId",
                principalTable: "Volunteers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VolunteerOrganizations_Organizations_OrganizationId",
                table: "VolunteerOrganizations",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VolunteerOrganizations_Volunteers_VolunteerId",
                table: "VolunteerOrganizations",
                column: "VolunteerId",
                principalTable: "Volunteers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactPeople_MilitaryUnits_MilitaryUnitId",
                table: "ContactPeople");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Volunteers_FromVolunteerId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Volunteers_ToVolunteerId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_VolunteerOrganizations_Organizations_OrganizationId",
                table: "VolunteerOrganizations");

            migrationBuilder.DropForeignKey(
                name: "FK_VolunteerOrganizations_Volunteers_VolunteerId",
                table: "VolunteerOrganizations");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VolunteerOrganizations",
                table: "VolunteerOrganizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactPeople",
                table: "ContactPeople");

            migrationBuilder.RenameTable(
                name: "VolunteerOrganizations",
                newName: "VolunteerOrganizationEntity");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "MessageEntity");

            migrationBuilder.RenameTable(
                name: "ContactPeople",
                newName: "ContactPersons");

            migrationBuilder.RenameIndex(
                name: "IX_VolunteerOrganizations_OrganizationId",
                table: "VolunteerOrganizationEntity",
                newName: "IX_VolunteerOrganizationEntity_OrganizationId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ToVolunteerId",
                table: "MessageEntity",
                newName: "IX_MessageEntity_ToVolunteerId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_FromVolunteerId",
                table: "MessageEntity",
                newName: "IX_MessageEntity_FromVolunteerId");

            migrationBuilder.RenameIndex(
                name: "IX_ContactPeople_MilitaryUnitId",
                table: "ContactPersons",
                newName: "IX_ContactPersons_MilitaryUnitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VolunteerOrganizationEntity",
                table: "VolunteerOrganizationEntity",
                columns: new[] { "VolunteerId", "OrganizationId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageEntity",
                table: "MessageEntity",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_MessageEntity_Volunteers_FromVolunteerId",
                table: "MessageEntity",
                column: "FromVolunteerId",
                principalTable: "Volunteers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageEntity_Volunteers_ToVolunteerId",
                table: "MessageEntity",
                column: "ToVolunteerId",
                principalTable: "Volunteers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VolunteerOrganizationEntity_Organizations_OrganizationId",
                table: "VolunteerOrganizationEntity",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VolunteerOrganizationEntity_Volunteers_VolunteerId",
                table: "VolunteerOrganizationEntity",
                column: "VolunteerId",
                principalTable: "Volunteers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
