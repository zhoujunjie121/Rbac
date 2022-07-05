using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassLibraryEF.Migrations
{
    public partial class _07051 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleAdmin_Admin_RoleId",
                table: "RoleAdmin");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleAdmin_Role_AdmimId",
                table: "RoleAdmin");

            migrationBuilder.DropIndex(
                name: "IX_RoleAdmin_AdmimId",
                table: "RoleAdmin");

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "RoleAdmin",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleAdmin_AdminId",
                table: "RoleAdmin",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleAdmin_Admin_AdminId",
                table: "RoleAdmin",
                column: "AdminId",
                principalTable: "Admin",
                principalColumn: "AdminId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleAdmin_Role_RoleId",
                table: "RoleAdmin",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleAdmin_Admin_AdminId",
                table: "RoleAdmin");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleAdmin_Role_RoleId",
                table: "RoleAdmin");

            migrationBuilder.DropIndex(
                name: "IX_RoleAdmin_AdminId",
                table: "RoleAdmin");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "RoleAdmin");

            migrationBuilder.CreateIndex(
                name: "IX_RoleAdmin_AdmimId",
                table: "RoleAdmin",
                column: "AdmimId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleAdmin_Admin_RoleId",
                table: "RoleAdmin",
                column: "RoleId",
                principalTable: "Admin",
                principalColumn: "AdminId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleAdmin_Role_AdmimId",
                table: "RoleAdmin",
                column: "AdmimId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
