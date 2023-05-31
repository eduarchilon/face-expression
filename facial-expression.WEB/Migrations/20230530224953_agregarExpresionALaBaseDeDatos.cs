using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace facial_expression.WEB.Migrations
{
    /// <inheritdoc />
    public partial class agregarExpresionALaBaseDeDatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Expression",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreImagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    clasificacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expression", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expression");
        }
    }
}
