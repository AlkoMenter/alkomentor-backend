using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alkomentor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBoozeProMelleDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CurrentProMilleUpdated",
                table: "Boozes",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentProMilleUpdated",
                table: "Boozes");
        }
    }
}
