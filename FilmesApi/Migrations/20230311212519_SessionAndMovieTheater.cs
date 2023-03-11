using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmesApi.Migrations
{
    /// <inheritdoc />
    public partial class SessionAndMovieTheater : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MovieTheaterId",
                table: "TB_Sessions",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Sessions_MovieTheaterId",
                table: "TB_Sessions",
                column: "MovieTheaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Sessions_TB_MovieTheataers_MovieTheaterId",
                table: "TB_Sessions",
                column: "MovieTheaterId",
                principalTable: "TB_MovieTheataers",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_Sessions_TB_MovieTheataers_MovieTheaterId",
                table: "TB_Sessions");

            migrationBuilder.DropIndex(
                name: "IX_TB_Sessions_MovieTheaterId",
                table: "TB_Sessions");

            migrationBuilder.DropColumn(
                name: "MovieTheaterId",
                table: "TB_Sessions");
        }
    }
}
