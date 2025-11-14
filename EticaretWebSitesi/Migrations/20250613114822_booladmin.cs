using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EticaretWebSitesi.Migrations
{
    /// <inheritdoc />
    public partial class booladmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Yetki",
                table: "admins",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "CHAR(1)",
                oldMaxLength: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Yetki",
                table: "admins",
                type: "CHAR(1)",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
