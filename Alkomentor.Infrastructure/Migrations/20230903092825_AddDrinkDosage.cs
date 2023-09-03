using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alkomentor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDrinkDosage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Dosage",
                table: "Drinks",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dosage",
                table: "Drinks");
        }
    }
}
