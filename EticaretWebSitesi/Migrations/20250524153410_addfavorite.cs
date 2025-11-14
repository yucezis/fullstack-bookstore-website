using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EticaretWebSitesi.Migrations
{
    /// <inheritdoc />
    public partial class addfavorite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "favoris",
                columns: table => new
                {
                    FavoriId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriId = table.Column<int>(type: "int", nullable: false),
                    UrunId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_favoris", x => x.FavoriId);
                    table.ForeignKey(
                        name: "FK_favoris_uruns_UrunId",
                        column: x => x.UrunId,
                        principalTable: "uruns",
                        principalColumn: "UrunId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_favoris_UrunId",
                table: "favoris",
                column: "UrunId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "favoris");
        }
    }
}
