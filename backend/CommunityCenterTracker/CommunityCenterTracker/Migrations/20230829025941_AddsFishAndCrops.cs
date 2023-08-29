using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommunityCenterTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddsFishAndCrops : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Season",
                table: "Items",
                newName: "Discriminator");

            migrationBuilder.AddColumn<int>(
                name: "DaysToGrow",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Locations",
                table: "Items",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Seasons",
                table: "Items",
                type: "jsonb",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Times",
                table: "Items",
                type: "jsonb",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DaysToGrow",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Locations",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Seasons",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Times",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "Discriminator",
                table: "Items",
                newName: "Season");
        }
    }
}
