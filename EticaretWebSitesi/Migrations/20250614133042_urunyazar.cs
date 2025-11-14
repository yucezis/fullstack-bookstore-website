using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EticaretWebSitesi.Migrations
{
    /// <inheritdoc />
    public partial class urunyazar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UrunYazar",
                table: "uruns",
                type: "VARCHAR(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(250)",
                oldMaxLength: 250);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UrunYazar",
                table: "uruns",
                type: "VARCHAR(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(250)",
                oldMaxLength: 250,
                oldNullable: true);
        }
    }
}
