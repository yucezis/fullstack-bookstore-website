using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EticaretWebSitesi.Migrations
{
    /// <inheritdoc />
    public partial class aciklama500 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "uruns",
                type: "VARCHAR(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(300)",
                oldMaxLength: 300);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "uruns",
                type: "VARCHAR(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(500)",
                oldMaxLength: 500);
        }
    }
}
