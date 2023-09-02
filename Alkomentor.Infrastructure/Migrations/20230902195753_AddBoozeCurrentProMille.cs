using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alkomentor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBoozeCurrentProMille : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Degree",
                table: "Drinks",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddColumn<double>(
                name: "CurrentProMille",
                table: "Boozes",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentProMille",
                table: "Boozes");

            migrationBuilder.AlterColumn<double>(
                name: "Degree",
                table: "Drinks",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);
        }
    }
}
