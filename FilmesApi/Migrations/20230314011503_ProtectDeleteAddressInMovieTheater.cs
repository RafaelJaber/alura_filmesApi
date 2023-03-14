using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmesApi.Migrations
{
    /// <inheritdoc />
    public partial class ProtectDeleteAddressInMovieTheater : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_MovieTheataers_TB_Addresses_AddressUid",
                table: "TB_MovieTheataers");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_MovieTheataers_TB_Addresses_AddressUid",
                table: "TB_MovieTheataers",
                column: "AddressUid",
                principalTable: "TB_Addresses",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_MovieTheataers_TB_Addresses_AddressUid",
                table: "TB_MovieTheataers");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_MovieTheataers_TB_Addresses_AddressUid",
                table: "TB_MovieTheataers",
                column: "AddressUid",
                principalTable: "TB_Addresses",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
