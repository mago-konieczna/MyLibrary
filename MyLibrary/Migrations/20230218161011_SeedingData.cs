using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLibrary.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Country", "LastName", "Name" },
                values: new object[] { 1, "Wielka Brytania", "Tolkien", "John Ronald Reuel" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Category", "Description", "Format", "Language", "NumberISBN", "Pages", "PublicationDate", "ReadingStatus", "Title" },
                values: new object[] { 1, "fantasy", "Wydanie klasycznego dzieła Tolkiena. Hobbit to istota większa od liliputa, mniejsza jednak od krasnala. Fantastyczny, przemyślany do najdrobniejszych szczegółów świat z powieści Tolkiena jest również jego osobistym tworem, a pod barwną fasadą nietrudno się dopatrzyć głębszego sensu i pewnych analogii do współczesności. ", "książka", "polski", 42701729, 320, new DateTime(2014, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Hobbit" });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "PublisherName" },
                values: new object[] { 1, "Wydawnictwo Iskry" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
