using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class changeKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Weathers",
                table: "Weathers");

            migrationBuilder.AddColumn<int>(
                name: "WeatherForecastId",
                table: "Weathers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weathers",
                table: "Weathers",
                column: "WeatherForecastId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Weathers",
                table: "Weathers");

            migrationBuilder.DropColumn(
                name: "WeatherForecastId",
                table: "Weathers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weathers",
                table: "Weathers",
                column: "Date");
        }
    }
}
