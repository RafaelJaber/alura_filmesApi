using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmesApi.Migrations
{
    /// <inheritdoc />
    public partial class MovieAndMovieTheater : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_Sessions_TB_MovieTheataers_MovieTheaterId",
                table: "TB_Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_Sessions_TB_Movie_MovieId",
                table: "TB_Sessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_Sessions",
                table: "TB_Sessions");

            migrationBuilder.DropIndex(
                name: "IX_TB_Sessions_MovieId",
                table: "TB_Sessions");

            migrationBuilder.AlterColumn<Guid>(
                name: "MovieTheaterId",
                table: "TB_Sessions",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "MovieId",
                table: "TB_Sessions",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_Sessions",
                table: "TB_Sessions",
                columns: new[] { "MovieId", "MovieTheaterId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Sessions_TB_MovieTheataers_MovieTheaterId",
                table: "TB_Sessions",
                column: "MovieTheaterId",
                principalTable: "TB_MovieTheataers",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Sessions_TB_Movie_MovieId",
                table: "TB_Sessions",
                column: "MovieId",
                principalTable: "TB_Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_Sessions_TB_MovieTheataers_MovieTheaterId",
                table: "TB_Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_Sessions_TB_Movie_MovieId",
                table: "TB_Sessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_Sessions",
                table: "TB_Sessions");

            migrationBuilder.AlterColumn<Guid>(
                name: "MovieTheaterId",
                table: "TB_Sessions",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "MovieId",
                table: "TB_Sessions",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_Sessions",
                table: "TB_Sessions",
                column: "Uid");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Sessions_MovieId",
                table: "TB_Sessions",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Sessions_TB_MovieTheataers_MovieTheaterId",
                table: "TB_Sessions",
                column: "MovieTheaterId",
                principalTable: "TB_MovieTheataers",
                principalColumn: "Uid");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Sessions_TB_Movie_MovieId",
                table: "TB_Sessions",
                column: "MovieId",
                principalTable: "TB_Movie",
                principalColumn: "Id");
        }
    }
}
