using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi03.Migrations
{
    /// <inheritdoc />
    public partial class WebApi03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorsID);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    PublishersID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.PublishersID);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRead = table.Column<bool>(type: "bit", nullable: true),
                    DateRead = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Rate = table.Column<int>(type: "int", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoverUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PublisherID = table.Column<int>(type: "int", nullable: false),
                    PublishersID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookID);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublishersID",
                        column: x => x.PublishersID,
                        principalTable: "Publishers",
                        principalColumn: "PublishersID");
                });

            migrationBuilder.CreateTable(
                name: "BookAuthor",
                columns: table => new
                {
                    BooksID = table.Column<int>(type: "int", nullable: false),
                    AuthorsID = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthor", x => new { x.BooksID, x.AuthorsID });
                    table.ForeignKey(
                        name: "FK_BookAuthor_Authors_AuthorsID",
                        column: x => x.AuthorsID,
                        principalTable: "Authors",
                        principalColumn: "AuthorsID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthor_Books_BooksID",
                        column: x => x.BooksID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorsID", "FullName" },
                values: new object[,]
                {
                    { 1, "Phan Hồ Anh Kha" },
                    { 2, "Cao Mai Hương" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookID", "CoverUrl", "DateAdded", "DateRead", "Description", "Genre", "IsRead", "PublisherID", "PublishersID", "Rate", "Title" },
                values: new object[,]
                {
                    { 1, "https://images.example.com/Book.jpg", new DateTime(2024, 5, 5, 16, 25, 10, 725, DateTimeKind.Local).AddTicks(8137), new DateTime(2024, 5, 5, 16, 25, 10, 725, DateTimeKind.Local).AddTicks(8124), "Hành trình đi tìm ngọc rồng của cậu bé Songoku.", null, true, 1, null, 10, "Bảy Viên Ngọc Rồng" },
                    { 2, "https://images.example.com/BookNaruto.jpg", new DateTime(2024, 5, 5, 16, 25, 10, 725, DateTimeKind.Local).AddTicks(8143), new DateTime(2024, 5, 5, 16, 25, 10, 725, DateTimeKind.Local).AddTicks(8142), "Hành trình phưu lưu của cậu bé mồ côi.", null, true, 2, null, 5, "Naruto" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "PublishersID", "Name" },
                values: new object[,]
                {
                    { 1, "Khổng Tử" },
                    { 2, "Hồ Chí Minh" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthor_AuthorsID",
                table: "BookAuthor",
                column: "AuthorsID");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublishersID",
                table: "Books",
                column: "PublishersID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthor");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
