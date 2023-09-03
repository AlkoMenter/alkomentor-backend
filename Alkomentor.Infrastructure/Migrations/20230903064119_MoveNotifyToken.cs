using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alkomentor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MoveNotifyToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotifyToken",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "NotifyToken",
                table: "Profiles",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotifyToken",
                table: "Profiles");

            migrationBuilder.AddColumn<string>(
                name: "NotifyToken",
                table: "Accounts",
                type: "text",
                nullable: true);
        }
    }
}
