using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassLibraryEF.Migrations
{
    public partial class _07052 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleMeun_Menu_MenuId",
                table: "RoleMeun");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleMeun_Role_RoleId",
                table: "RoleMeun");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleMeun",
                table: "RoleMeun");

            migrationBuilder.RenameTable(
                name: "RoleMeun",
                newName: "RoleMenu");

            migrationBuilder.RenameIndex(
                name: "IX_RoleMeun_RoleId",
                table: "RoleMenu",
                newName: "IX_RoleMenu_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_RoleMeun_MenuId",
                table: "RoleMenu",
                newName: "IX_RoleMenu_MenuId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleMenu",
                table: "RoleMenu",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleMenu_Menu_MenuId",
                table: "RoleMenu",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "MenuId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleMenu_Role_RoleId",
                table: "RoleMenu",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleMenu_Menu_MenuId",
                table: "RoleMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleMenu_Role_RoleId",
                table: "RoleMenu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleMenu",
                table: "RoleMenu");

            migrationBuilder.RenameTable(
                name: "RoleMenu",
                newName: "RoleMeun");

            migrationBuilder.RenameIndex(
                name: "IX_RoleMenu_RoleId",
                table: "RoleMeun",
                newName: "IX_RoleMeun_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_RoleMenu_MenuId",
                table: "RoleMeun",
                newName: "IX_RoleMeun_MenuId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleMeun",
                table: "RoleMeun",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleMeun_Menu_MenuId",
                table: "RoleMeun",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "MenuId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleMeun_Role_RoleId",
                table: "RoleMeun",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
