using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmesApi.Migrations
{
    /// <inheritdoc />
    public partial class reanmeDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieTheaters_TB_Addresses_AddressUid",
                table: "MovieTheaters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieTheaters",
                table: "MovieTheaters");

            migrationBuilder.RenameTable(
                name: "MovieTheaters",
                newName: "TB_MovieTheataers");

            migrationBuilder.RenameIndex(
                name: "IX_MovieTheaters_AddressUid",
                table: "TB_MovieTheataers",
                newName: "IX_TB_MovieTheataers_AddressUid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_MovieTheataers",
                table: "TB_MovieTheataers",
                column: "Uid");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_MovieTheataers_TB_Addresses_AddressUid",
                table: "TB_MovieTheataers",
                column: "AddressUid",
                principalTable: "TB_Addresses",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_MovieTheataers_TB_Addresses_AddressUid",
                table: "TB_MovieTheataers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_MovieTheataers",
                table: "TB_MovieTheataers");

            migrationBuilder.RenameTable(
                name: "TB_MovieTheataers",
                newName: "MovieTheaters");

            migrationBuilder.RenameIndex(
                name: "IX_TB_MovieTheataers_AddressUid",
                table: "MovieTheaters",
                newName: "IX_MovieTheaters_AddressUid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieTheaters",
                table: "MovieTheaters",
                column: "Uid");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieTheaters_TB_Addresses_AddressUid",
                table: "MovieTheaters",
                column: "AddressUid",
                principalTable: "TB_Addresses",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
