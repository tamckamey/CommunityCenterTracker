using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CommunityCenterTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddsControllers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bundles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SectionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bundles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bundles_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Seasons = table.Column<string>(type: "jsonb", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true),
                    BundleId = table.Column<int>(type: "integer", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    DaysToGrow = table.Column<int>(type: "integer", nullable: true),
                    Times = table.Column<string>(type: "jsonb", nullable: true),
                    Locations = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Bundles_BundleId",
                        column: x => x.BundleId,
                        principalTable: "Bundles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bundles_SectionId",
                table: "Bundles",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_BundleId",
                table: "Items",
                column: "BundleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Bundles");

            migrationBuilder.DropTable(
                name: "Sections");
        }
    }
}
