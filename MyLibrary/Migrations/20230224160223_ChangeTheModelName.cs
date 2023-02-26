using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLibrary.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTheModelName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookPublishers");

            migrationBuilder.CreateTable(
                name: "BookPublisher",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    PublishersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookPublisher", x => new { x.BooksId, x.PublishersId });
                    table.ForeignKey(
                        name: "FK_BookPublisher_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookPublisher_Publishers_PublishersId",
                        column: x => x.PublishersId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookPublisher_PublishersId",
                table: "BookPublisher",
                column: "PublishersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookPublisher");

            migrationBuilder.CreateTable(
                name: "BookPublishers",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    PublishersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookPublishers", x => new { x.BooksId, x.PublishersId });
                    table.ForeignKey(
                        name: "FK_BookPublishers_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookPublishers_Publishers_PublishersId",
                        column: x => x.PublishersId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookPublishers_PublishersId",
                table: "BookPublishers",
                column: "PublishersId");
        }
    }
}
