using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig_ModifyGeneralSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SettingTypeId",
                table: "GeneralSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GeneralSettings_SettingTypeId",
                table: "GeneralSettings",
                column: "SettingTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralSettings_TypeLookups_SettingTypeId",
                table: "GeneralSettings",
                column: "SettingTypeId",
                principalTable: "TypeLookups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneralSettings_TypeLookups_SettingTypeId",
                table: "GeneralSettings");

            migrationBuilder.DropIndex(
                name: "IX_GeneralSettings_SettingTypeId",
                table: "GeneralSettings");

            migrationBuilder.DropColumn(
                name: "SettingTypeId",
                table: "GeneralSettings");
        }
    }
}
