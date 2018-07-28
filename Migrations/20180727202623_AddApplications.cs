using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BEASTAPI.Migrations
{
    public partial class AddApplications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Applicationid",
                table: "Beasts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beasts_Applicationid",
                table: "Beasts",
                column: "Applicationid");

            migrationBuilder.AddForeignKey(
                name: "FK_Beasts_Applications_Applicationid",
                table: "Beasts",
                column: "Applicationid",
                principalTable: "Applications",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beasts_Applications_Applicationid",
                table: "Beasts");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Beasts_Applicationid",
                table: "Beasts");

            migrationBuilder.DropColumn(
                name: "Applicationid",
                table: "Beasts");
        }
    }
}
