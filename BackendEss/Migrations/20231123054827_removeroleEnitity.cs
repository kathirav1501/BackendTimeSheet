using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendEss.Migrations
{
    /// <inheritdoc />
    public partial class removeroleEnitity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Roles_RoleID",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_RoleID",
                table: "AppUsers");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_RoleID",
                table: "AppUsers",
                column: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_Roles_RoleID",
                table: "AppUsers",
                column: "RoleID",
                principalTable: "Roles",
                principalColumn: "RoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Roles_RoleID",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_RoleID",
                table: "AppUsers");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_RoleID",
                table: "AppUsers",
                column: "RoleID",
                unique: true,
                filter: "[RoleID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_Roles_RoleID",
                table: "AppUsers",
                column: "RoleID",
                principalTable: "Roles",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
