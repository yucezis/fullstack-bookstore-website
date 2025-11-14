using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EticaretWebSitesi.Migrations
{
    /// <inheritdoc />
    public partial class indirimEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "IndirimliFiyat",
                table: "uruns",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IndirimliFiyat",
                table: "uruns");
        }
    }
}
