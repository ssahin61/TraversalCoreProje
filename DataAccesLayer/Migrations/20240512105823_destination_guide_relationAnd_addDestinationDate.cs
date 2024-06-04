using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccesLayer.Migrations
{
    public partial class destination_guide_relationAnd_addDestinationDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Destinations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "GuideID",
                table: "Destinations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_GuideID",
                table: "Destinations",
                column: "GuideID");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Guides_GuideID",
                table: "Destinations",
                column: "GuideID",
                principalTable: "Guides",
                principalColumn: "GuideID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Guides_GuideID",
                table: "Destinations");

            migrationBuilder.DropIndex(
                name: "IX_Destinations_GuideID",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "GuideID",
                table: "Destinations");
        }
    }
}
