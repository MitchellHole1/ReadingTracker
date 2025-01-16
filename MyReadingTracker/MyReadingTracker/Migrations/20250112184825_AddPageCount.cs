using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyReadingTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddPageCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Series_SeriesId1",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_SeriesId1",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "SeriesId1",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "GenreIds",
                table: "Books",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pages",
                table: "Books",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GenreIds",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Pages",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "SeriesId1",
                table: "Books",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_SeriesId1",
                table: "Books",
                column: "SeriesId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Series_SeriesId1",
                table: "Books",
                column: "SeriesId1",
                principalTable: "Series",
                principalColumn: "Id");
        }
    }
}
