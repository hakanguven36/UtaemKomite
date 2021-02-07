using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UtaemKomite.Migrations
{
    public partial class mig00 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kullar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kulname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    kulpass = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    hatirla = table.Column<bool>(type: "bit", nullable: false),
                    cerez = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    hatali = table.Column<int>(type: "int", nullable: false),
                    kilitliTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    admin = table.Column<bool>(type: "bit", nullable: false),
                    adminCode = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Prodosya",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kulID = table.Column<int>(type: "int", nullable: false),
                    projeID = table.Column<int>(type: "int", nullable: false),
                    versiyon = table.Column<int>(type: "int", nullable: false),
                    orjisim = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    orjuzantı = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    sysname = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    bytenumber = table.Column<int>(type: "int", nullable: false),
                    tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    downloads = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodosya", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Proje",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kulID = table.Column<int>(type: "int", nullable: false),
                    isim = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    durum = table.Column<int>(type: "int", nullable: false),
                    görünür = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proje", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Toplantı",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gündem = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toplantı", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tutanak",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToplantıID = table.Column<int>(type: "int", nullable: false),
                    kulID = table.Column<int>(type: "int", nullable: false),
                    projeID = table.Column<int>(type: "int", nullable: false),
                    yazanID = table.Column<int>(type: "int", nullable: false),
                    tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    metin = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutanak", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kullar");

            migrationBuilder.DropTable(
                name: "Prodosya");

            migrationBuilder.DropTable(
                name: "Proje");

            migrationBuilder.DropTable(
                name: "Toplantı");

            migrationBuilder.DropTable(
                name: "Tutanak");
        }
    }
}
