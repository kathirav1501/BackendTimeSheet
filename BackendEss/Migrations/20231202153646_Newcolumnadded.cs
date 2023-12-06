using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendEss.Migrations
{
    /// <inheritdoc />
    public partial class Newcolumnadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "HoursSpent",
                table: "Tasks",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoursSpent",
                table: "Tasks");
        }
    }
}
