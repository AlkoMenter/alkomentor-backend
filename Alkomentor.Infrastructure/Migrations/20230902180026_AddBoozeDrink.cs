using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alkomentor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBoozeDrink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoozeDrink",
                columns: table => new
                {
                    BoozesId = table.Column<Guid>(type: "uuid", nullable: false),
                    SelectedDrinksId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoozeDrink", x => new { x.BoozesId, x.SelectedDrinksId });
                    table.ForeignKey(
                        name: "FK_BoozeDrink_Boozes_BoozesId",
                        column: x => x.BoozesId,
                        principalTable: "Boozes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoozeDrink_Drinks_SelectedDrinksId",
                        column: x => x.SelectedDrinksId,
                        principalTable: "Drinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoozeDrink_SelectedDrinksId",
                table: "BoozeDrink",
                column: "SelectedDrinksId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoozeDrink");
        }
    }
}
