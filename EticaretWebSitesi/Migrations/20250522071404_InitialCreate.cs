using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EticaretWebSitesi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    Sifre = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    Yetki = table.Column<string>(type: "CHAR(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "faturalars",
                columns: table => new
                {
                    FaturaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaturaSeriNo = table.Column<string>(type: "CHAR(1)", maxLength: 1, nullable: false),
                    FaturaSıraNo = table.Column<string>(type: "VARCHAR(6)", maxLength: 6, nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Saat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VergiDairesi = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    TeslimEden = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    TeslimAlan = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_faturalars", x => x.FaturaId);
                });

            migrationBuilder.CreateTable(
                name: "kategoris",
                columns: table => new
                {
                    KategoriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kategoris", x => x.KategoriID);
                });

            migrationBuilder.CreateTable(
                name: "musteris",
                columns: table => new
                {
                    MusteriId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriAdi = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    MusteriSoyadi = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    MusteriSehir = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: false),
                    MusteriMail = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    MusteriSifre = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Durum = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_musteris", x => x.MusteriId);
                });

            migrationBuilder.CreateTable(
                name: "faturaIcis",
                columns: table => new
                {
                    FaturaIciId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aciklama = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Miktar = table.Column<int>(type: "int", nullable: false),
                    BirimFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FaturaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_faturaIcis", x => x.FaturaIciId);
                    table.ForeignKey(
                        name: "FK_faturaIcis_faturalars_FaturaId",
                        column: x => x.FaturaId,
                        principalTable: "faturalars",
                        principalColumn: "FaturaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "uruns",
                columns: table => new
                {
                    UrunId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunAdi = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    UrunMarka = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    UrunYazar = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    UrunStok = table.Column<short>(type: "smallint", nullable: false),
                    UrunSatisFiyati = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UrunStokDurum = table.Column<bool>(type: "bit", nullable: false),
                    UrunGorsel = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    KategoriID = table.Column<int>(type: "int", nullable: false),
                    Durum = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uruns", x => x.UrunId);
                    table.ForeignKey(
                        name: "FK_uruns_kategoris_KategoriID",
                        column: x => x.KategoriID,
                        principalTable: "kategoris",
                        principalColumn: "KategoriID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "satisHarekets",
                columns: table => new
                {
                    SatisHareketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adet = table.Column<int>(type: "int", nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ToplamTutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UrunId = table.Column<int>(type: "int", nullable: false),
                    MusteriId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_satisHarekets", x => x.SatisHareketId);
                    table.ForeignKey(
                        name: "FK_satisHarekets_musteris_MusteriId",
                        column: x => x.MusteriId,
                        principalTable: "musteris",
                        principalColumn: "MusteriId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_satisHarekets_uruns_UrunId",
                        column: x => x.UrunId,
                        principalTable: "uruns",
                        principalColumn: "UrunId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_faturaIcis_FaturaId",
                table: "faturaIcis",
                column: "FaturaId");

            migrationBuilder.CreateIndex(
                name: "IX_satisHarekets_MusteriId",
                table: "satisHarekets",
                column: "MusteriId");

            migrationBuilder.CreateIndex(
                name: "IX_satisHarekets_UrunId",
                table: "satisHarekets",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_uruns_KategoriID",
                table: "uruns",
                column: "KategoriID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "faturaIcis");

            migrationBuilder.DropTable(
                name: "satisHarekets");

            migrationBuilder.DropTable(
                name: "faturalars");

            migrationBuilder.DropTable(
                name: "musteris");

            migrationBuilder.DropTable(
                name: "uruns");

            migrationBuilder.DropTable(
                name: "kategoris");
        }
    }
}
