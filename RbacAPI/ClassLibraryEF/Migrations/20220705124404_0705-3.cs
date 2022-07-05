using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassLibraryEF.Migrations
{
    public partial class _07053 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleAdmin_Admin_AdminId",
                table: "RoleAdmin");

            migrationBuilder.DropColumn(
                name: "AdmimId",
                table: "RoleAdmin");

            migrationBuilder.AlterColumn<int>(
                name: "AdminId",
                table: "RoleAdmin",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleAdmin_Admin_AdminId",
                table: "RoleAdmin",
                column: "AdminId",
                principalTable: "Admin",
                principalColumn: "AdminId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleAdmin_Admin_AdminId",
                table: "RoleAdmin");

            migrationBuilder.AlterColumn<int>(
                name: "AdminId",
                table: "RoleAdmin",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AdmimId",
                table: "RoleAdmin",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleAdmin_Admin_AdminId",
                table: "RoleAdmin",
                column: "AdminId",
                principalTable: "Admin",
                principalColumn: "AdminId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
