using Microsoft.EntityFrameworkCore.Migrations;

namespace Tutor.Infrastructure.Migrations
{
    public partial class MetricRanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MetricRangeRules_BasicMetricCheckers_ClassMetricCheckerFore~",
                table: "MetricRangeRules");

            migrationBuilder.DropForeignKey(
                name: "FK_MetricRangeRules_BasicMetricCheckers_MethodMetricCheckerFor~",
                table: "MetricRangeRules");

            migrationBuilder.DropIndex(
                name: "IX_MetricRangeRules_ClassMetricCheckerForeignKey",
                table: "MetricRangeRules");

            migrationBuilder.DropColumn(
                name: "ClassMetricCheckerForeignKey",
                table: "MetricRangeRules");

            migrationBuilder.RenameColumn(
                name: "MethodMetricCheckerForeignKey",
                table: "MetricRangeRules",
                newName: "MetricCheckerForeignKey");

            migrationBuilder.RenameIndex(
                name: "IX_MetricRangeRules_MethodMetricCheckerForeignKey",
                table: "MetricRangeRules",
                newName: "IX_MetricRangeRules_MetricCheckerForeignKey");

            migrationBuilder.RenameColumn(
                name: "CodeSnippedId",
                table: "ChallengeFulfillmentStrategies",
                newName: "CodeSnippetId");

            migrationBuilder.AddForeignKey(
                name: "FK_MetricRangeRules_BasicMetricCheckers_MetricCheckerForeignKey",
                table: "MetricRangeRules",
                column: "MetricCheckerForeignKey",
                principalTable: "BasicMetricCheckers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MetricRangeRules_BasicMetricCheckers_MetricCheckerForeignKey",
                table: "MetricRangeRules");

            migrationBuilder.RenameColumn(
                name: "MetricCheckerForeignKey",
                table: "MetricRangeRules",
                newName: "MethodMetricCheckerForeignKey");

            migrationBuilder.RenameIndex(
                name: "IX_MetricRangeRules_MetricCheckerForeignKey",
                table: "MetricRangeRules",
                newName: "IX_MetricRangeRules_MethodMetricCheckerForeignKey");

            migrationBuilder.RenameColumn(
                name: "CodeSnippetId",
                table: "ChallengeFulfillmentStrategies",
                newName: "CodeSnippedId");

            migrationBuilder.AddColumn<int>(
                name: "ClassMetricCheckerForeignKey",
                table: "MetricRangeRules",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MetricRangeRules_ClassMetricCheckerForeignKey",
                table: "MetricRangeRules",
                column: "ClassMetricCheckerForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_MetricRangeRules_BasicMetricCheckers_ClassMetricCheckerFore~",
                table: "MetricRangeRules",
                column: "ClassMetricCheckerForeignKey",
                principalTable: "BasicMetricCheckers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MetricRangeRules_BasicMetricCheckers_MethodMetricCheckerFor~",
                table: "MetricRangeRules",
                column: "MethodMetricCheckerForeignKey",
                principalTable: "BasicMetricCheckers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
