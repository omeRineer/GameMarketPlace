using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig_NewProcessGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProcessGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecordState = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusLookups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProcessGroupId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecordState = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusLookups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatusLookups_ProcessGroups_ProcessGroupId",
                        column: x => x.ProcessGroupId,
                        principalTable: "ProcessGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypeLookups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProcessGroupId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecordState = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeLookups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeLookups_ProcessGroups_ProcessGroupId",
                        column: x => x.ProcessGroupId,
                        principalTable: "ProcessGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SystemRequirements_SystemRequirementTypeId",
                table: "SystemRequirements",
                column: "SystemRequirementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Medias_MediaTypeId",
                table: "Medias",
                column: "MediaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusLookups_ProcessGroupId",
                table: "StatusLookups",
                column: "ProcessGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeLookups_ProcessGroupId",
                table: "TypeLookups",
                column: "ProcessGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_TypeLookups_MediaTypeId",
                table: "Medias",
                column: "MediaTypeId",
                principalTable: "TypeLookups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SystemRequirements_TypeLookups_SystemRequirementTypeId",
                table: "SystemRequirements",
                column: "SystemRequirementTypeId",
                principalTable: "TypeLookups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_TypeLookups_MediaTypeId",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_SystemRequirements_TypeLookups_SystemRequirementTypeId",
                table: "SystemRequirements");

            migrationBuilder.DropTable(
                name: "StatusLookups");

            migrationBuilder.DropTable(
                name: "TypeLookups");

            migrationBuilder.DropTable(
                name: "ProcessGroups");

            migrationBuilder.DropIndex(
                name: "IX_SystemRequirements_SystemRequirementTypeId",
                table: "SystemRequirements");

            migrationBuilder.DropIndex(
                name: "IX_Medias_MediaTypeId",
                table: "Medias");
        }
    }
}
