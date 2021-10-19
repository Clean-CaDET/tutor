using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Tutor.Infrastructure.Migrations
{
    public partial class KnowledgeComponentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KnowledgeComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    KnowledgeComponentId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnowledgeComponents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KnowledgeComponents_KnowledgeComponents_KnowledgeComponentId",
                        column: x => x.KnowledgeComponentId,
                        principalTable: "KnowledgeComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KnowledgeComponentsProgresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Progress = table.Column<double>(type: "double precision", nullable: false),
                    KnowledgeComponentId = table.Column<int>(type: "integer", nullable: false),
                    LearnerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnowledgeComponentsProgresses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KnowledgeComponents_KnowledgeComponentId",
                table: "KnowledgeComponents",
                column: "KnowledgeComponentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KnowledgeComponents");

            migrationBuilder.DropTable(
                name: "KnowledgeComponentsProgresses");
        }
    }
}
