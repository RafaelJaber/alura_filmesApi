using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmesApi.Migrations
{
    /// <inheritdoc />
    public partial class AddresAndMovieTheater : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AddressUid",
                table: "MovieTheaters",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "TB_Addresses",
                columns: table => new
                {
                    Uid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    LineOne = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LineTwo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Addresses", x => x.Uid);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_MovieTheaters_AddressUid",
                table: "MovieTheaters",
                column: "AddressUid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieTheaters_TB_Addresses_AddressUid",
                table: "MovieTheaters",
                column: "AddressUid",
                principalTable: "TB_Addresses",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieTheaters_TB_Addresses_AddressUid",
                table: "MovieTheaters");

            migrationBuilder.DropTable(
                name: "TB_Addresses");

            migrationBuilder.DropIndex(
                name: "IX_MovieTheaters_AddressUid",
                table: "MovieTheaters");

            migrationBuilder.DropColumn(
                name: "AddressUid",
                table: "MovieTheaters");
        }
    }
}
