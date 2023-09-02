using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alkomentor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBoozeDomain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boozes_Profiles_ProfileId",
                table: "Boozes");

            migrationBuilder.DropTable(
                name: "BoozeDrinks");

            migrationBuilder.RenameColumn(
                name: "Dosage",
                table: "Drinks",
                newName: "Degree");

            migrationBuilder.RenameColumn(
                name: "Alc",
                table: "Drinks",
                newName: "AlcoholPerGram");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfileId",
                table: "Boozes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NotifyToken",
                table: "Accounts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "Gulps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BoozeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Size = table.Column<double>(type: "double precision", nullable: false),
                    DrinkId = table.Column<Guid>(type: "uuid", nullable: false),
                    GulpTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gulps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gulps_Boozes_BoozeId",
                        column: x => x.BoozeId,
                        principalTable: "Boozes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gulps_Drinks_DrinkId",
                        column: x => x.DrinkId,
                        principalTable: "Drinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gulps_BoozeId",
                table: "Gulps",
                column: "BoozeId");

            migrationBuilder.CreateIndex(
                name: "IX_Gulps_DrinkId",
                table: "Gulps",
                column: "DrinkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boozes_Profiles_ProfileId",
                table: "Boozes",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boozes_Profiles_ProfileId",
                table: "Boozes");

            migrationBuilder.DropTable(
                name: "Gulps");

            migrationBuilder.RenameColumn(
                name: "Degree",
                table: "Drinks",
                newName: "Dosage");

            migrationBuilder.RenameColumn(
                name: "AlcoholPerGram",
                table: "Drinks",
                newName: "Alc");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfileId",
                table: "Boozes",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "NotifyToken",
                table: "Accounts",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "BoozeDrinks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BoozeId = table.Column<Guid>(type: "uuid", nullable: true),
                    DrinkId = table.Column<Guid>(type: "uuid", nullable: true),
                    FactTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PlanTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Size = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoozeDrinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoozeDrinks_Boozes_BoozeId",
                        column: x => x.BoozeId,
                        principalTable: "Boozes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BoozeDrinks_Drinks_DrinkId",
                        column: x => x.DrinkId,
                        principalTable: "Drinks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoozeDrinks_BoozeId",
                table: "BoozeDrinks",
                column: "BoozeId");

            migrationBuilder.CreateIndex(
                name: "IX_BoozeDrinks_DrinkId",
                table: "BoozeDrinks",
                column: "DrinkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boozes_Profiles_ProfileId",
                table: "Boozes",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id");
        }
    }
}
