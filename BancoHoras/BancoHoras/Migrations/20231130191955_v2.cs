using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BancoHoras.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TempoTotal",
                table: "Categories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TempoTotal",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
