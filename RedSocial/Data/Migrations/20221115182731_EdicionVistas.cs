using Microsoft.EntityFrameworkCore.Migrations;

namespace RedSocial.Data.Migrations
{
    public partial class EdicionVistas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AmigosId",
                table: "usuarios",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Amigos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amigos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_AmigosId",
                table: "usuarios",
                column: "AmigosId");

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_Amigos_AmigosId",
                table: "usuarios",
                column: "AmigosId",
                principalTable: "Amigos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_Amigos_AmigosId",
                table: "usuarios");

            migrationBuilder.DropTable(
                name: "Amigos");

            migrationBuilder.DropIndex(
                name: "IX_usuarios_AmigosId",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "AmigosId",
                table: "usuarios");
        }
    }
}
