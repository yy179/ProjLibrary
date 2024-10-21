using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibrary.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MilitaryUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilitaryUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Volunteers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactPersons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MilitaryUnitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactPersons_MilitaryUnits_MilitaryUnitId",
                        column: x => x.MilitaryUnitId,
                        principalTable: "MilitaryUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromVolunteerId = table.Column<int>(type: "int", nullable: false),
                    ToVolunteerId = table.Column<int>(type: "int", nullable: false),
                    SentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageEntity_Volunteers_FromVolunteerId",
                        column: x => x.FromVolunteerId,
                        principalTable: "Volunteers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MessageEntity_Volunteers_ToVolunteerId",
                        column: x => x.ToVolunteerId,
                        principalTable: "Volunteers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Importance = table.Column<int>(type: "int", nullable: false),
                    CompletedByVolunteerId = table.Column<int>(type: "int", nullable: true),
                    TakenByVolunteerId = table.Column<int>(type: "int", nullable: true),
                    OrganizationCompletedById = table.Column<int>(type: "int", nullable: true),
                    OrganizationTakenById = table.Column<int>(type: "int", nullable: true),
                    MilitaryUnitId = table.Column<int>(type: "int", nullable: false),
                    MilitaryUnitEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_MilitaryUnits_MilitaryUnitEntityId",
                        column: x => x.MilitaryUnitEntityId,
                        principalTable: "MilitaryUnits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Requests_MilitaryUnits_MilitaryUnitId",
                        column: x => x.MilitaryUnitId,
                        principalTable: "MilitaryUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Organizations_OrganizationCompletedById",
                        column: x => x.OrganizationCompletedById,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Requests_Organizations_OrganizationTakenById",
                        column: x => x.OrganizationTakenById,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Requests_Volunteers_CompletedByVolunteerId",
                        column: x => x.CompletedByVolunteerId,
                        principalTable: "Volunteers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Volunteers_TakenByVolunteerId",
                        column: x => x.TakenByVolunteerId,
                        principalTable: "Volunteers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VolunteerOrganizationEntity",
                columns: table => new
                {
                    VolunteerId = table.Column<int>(type: "int", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    JoinedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteerOrganizationEntity", x => new { x.VolunteerId, x.OrganizationId });
                    table.ForeignKey(
                        name: "FK_VolunteerOrganizationEntity_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VolunteerOrganizationEntity_Volunteers_VolunteerId",
                        column: x => x.VolunteerId,
                        principalTable: "Volunteers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactPersons_MilitaryUnitId",
                table: "ContactPersons",
                column: "MilitaryUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageEntity_FromVolunteerId",
                table: "MessageEntity",
                column: "FromVolunteerId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageEntity_ToVolunteerId",
                table: "MessageEntity",
                column: "ToVolunteerId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_CompletedByVolunteerId",
                table: "Requests",
                column: "CompletedByVolunteerId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_MilitaryUnitEntityId",
                table: "Requests",
                column: "MilitaryUnitEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_MilitaryUnitId",
                table: "Requests",
                column: "MilitaryUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_OrganizationCompletedById",
                table: "Requests",
                column: "OrganizationCompletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_OrganizationTakenById",
                table: "Requests",
                column: "OrganizationTakenById");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_TakenByVolunteerId",
                table: "Requests",
                column: "TakenByVolunteerId");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerOrganizationEntity_OrganizationId",
                table: "VolunteerOrganizationEntity",
                column: "OrganizationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactPersons");

            migrationBuilder.DropTable(
                name: "MessageEntity");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "VolunteerOrganizationEntity");

            migrationBuilder.DropTable(
                name: "MilitaryUnits");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Volunteers");
        }
    }
}
