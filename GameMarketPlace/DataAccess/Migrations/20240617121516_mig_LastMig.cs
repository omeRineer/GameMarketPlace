using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig_LastMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatusLookups_ProcessGroups_ProcessGroupId",
                table: "StatusLookups");

            migrationBuilder.DropForeignKey(
                name: "FK_SystemRequirements_TypeLookups_SystemRequirementTypeId",
                table: "SystemRequirements");

            migrationBuilder.DropForeignKey(
                name: "FK_TypeLookups_ProcessGroups_ProcessGroupId",
                table: "TypeLookups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeLookups",
                table: "TypeLookups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatusLookups",
                table: "StatusLookups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProcessGroups",
                table: "ProcessGroups");

            migrationBuilder.RenameTable(
                name: "TypeLookups",
                newName: "TypeLookup");

            migrationBuilder.RenameTable(
                name: "StatusLookups",
                newName: "StatusLookup");

            migrationBuilder.RenameTable(
                name: "ProcessGroups",
                newName: "ProcessGroup");

            migrationBuilder.RenameIndex(
                name: "IX_TypeLookups_ProcessGroupId",
                table: "TypeLookup",
                newName: "IX_TypeLookup_ProcessGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_StatusLookups_ProcessGroupId",
                table: "StatusLookup",
                newName: "IX_StatusLookup_ProcessGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeLookup",
                table: "TypeLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatusLookup",
                table: "StatusLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProcessGroup",
                table: "ProcessGroup",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Medias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MediaTypeId = table.Column<int>(type: "int", nullable: false),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MediaPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecordState = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medias_TypeLookup_MediaTypeId",
                        column: x => x.MediaTypeId,
                        principalTable: "TypeLookup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medias_MediaTypeId",
                table: "Medias",
                column: "MediaTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_StatusLookup_ProcessGroup_ProcessGroupId",
                table: "StatusLookup",
                column: "ProcessGroupId",
                principalTable: "ProcessGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SystemRequirements_TypeLookup_SystemRequirementTypeId",
                table: "SystemRequirements",
                column: "SystemRequirementTypeId",
                principalTable: "TypeLookup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TypeLookup_ProcessGroup_ProcessGroupId",
                table: "TypeLookup",
                column: "ProcessGroupId",
                principalTable: "ProcessGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatusLookup_ProcessGroup_ProcessGroupId",
                table: "StatusLookup");

            migrationBuilder.DropForeignKey(
                name: "FK_SystemRequirements_TypeLookup_SystemRequirementTypeId",
                table: "SystemRequirements");

            migrationBuilder.DropForeignKey(
                name: "FK_TypeLookup_ProcessGroup_ProcessGroupId",
                table: "TypeLookup");

            migrationBuilder.DropTable(
                name: "Medias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeLookup",
                table: "TypeLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatusLookup",
                table: "StatusLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProcessGroup",
                table: "ProcessGroup");

            migrationBuilder.RenameTable(
                name: "TypeLookup",
                newName: "TypeLookups");

            migrationBuilder.RenameTable(
                name: "StatusLookup",
                newName: "StatusLookups");

            migrationBuilder.RenameTable(
                name: "ProcessGroup",
                newName: "ProcessGroups");

            migrationBuilder.RenameIndex(
                name: "IX_TypeLookup_ProcessGroupId",
                table: "TypeLookups",
                newName: "IX_TypeLookups_ProcessGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_StatusLookup_ProcessGroupId",
                table: "StatusLookups",
                newName: "IX_StatusLookups_ProcessGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeLookups",
                table: "TypeLookups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatusLookups",
                table: "StatusLookups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProcessGroups",
                table: "ProcessGroups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StatusLookups_ProcessGroups_ProcessGroupId",
                table: "StatusLookups",
                column: "ProcessGroupId",
                principalTable: "ProcessGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SystemRequirements_TypeLookups_SystemRequirementTypeId",
                table: "SystemRequirements",
                column: "SystemRequirementTypeId",
                principalTable: "TypeLookups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TypeLookups_ProcessGroups_ProcessGroupId",
                table: "TypeLookups",
                column: "ProcessGroupId",
                principalTable: "ProcessGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
