using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UtaemKomite.Migrations
{
    public partial class mig01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tutdosya",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    toplantıID = table.Column<int>(type: "int", nullable: false),
                    tutanakID = table.Column<int>(type: "int", nullable: false),
                    orjisim = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    orjuzantı = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    sysname = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    bytenumber = table.Column<int>(type: "int", nullable: false),
                    tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    downloads = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutdosya", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tutdosya");
        }
    }
}
