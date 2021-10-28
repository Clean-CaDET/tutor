using Microsoft.EntityFrameworkCore.Migrations;

namespace Tutor.Infrastructure.Migrations
{
    public partial class CodeSnippedId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodeSnippedId",
                table: "ChallengeFulfillmentStrategies",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodeSnippedId",
                table: "ChallengeFulfillmentStrategies");
        }
    }
}
