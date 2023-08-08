using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EFPostgresTest.Migrations
{
    /// <inheritdoc />
    public partial class AddCollectionsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CollectionId",
                table: "JacketsTable",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CollectionsTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionsTable", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JacketsTable_CollectionId",
                table: "JacketsTable",
                column: "CollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_JacketsTable_CollectionsTable_CollectionId",
                table: "JacketsTable",
                column: "CollectionId",
                principalTable: "CollectionsTable",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JacketsTable_CollectionsTable_CollectionId",
                table: "JacketsTable");

            migrationBuilder.DropTable(
                name: "CollectionsTable");

            migrationBuilder.DropIndex(
                name: "IX_JacketsTable_CollectionId",
                table: "JacketsTable");

            migrationBuilder.DropColumn(
                name: "CollectionId",
                table: "JacketsTable");
        }
    }
}
