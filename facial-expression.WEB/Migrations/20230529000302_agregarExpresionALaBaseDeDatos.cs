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
            migrationBuilder.AddColumn<string>(
                name: "nombreImagen",
                table: "Expression",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nombreImagen",
                table: "Expression");
        }
    }
}
