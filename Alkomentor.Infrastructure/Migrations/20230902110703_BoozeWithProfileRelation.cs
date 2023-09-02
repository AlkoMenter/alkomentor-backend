using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alkomentor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BoozeWithProfileRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProfileId",
                table: "Boozes",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Boozes_ProfileId",
                table: "Boozes",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boozes_Profiles_ProfileId",
                table: "Boozes",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boozes_Profiles_ProfileId",
                table: "Boozes");

            migrationBuilder.DropIndex(
                name: "IX_Boozes_ProfileId",
                table: "Boozes");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Boozes");
        }
    }
}
