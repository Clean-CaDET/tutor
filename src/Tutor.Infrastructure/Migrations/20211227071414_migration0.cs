using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tutor.Infrastructure.Migrations
{
    public partial class migration0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeStamp",
                table: "Submissions",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<double>(
                name: "CorrectnessLevel",
                table: "Submissions",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "KnowledgeComponents",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_AssessmentEventId",
                table: "Submissions",
                column: "AssessmentEventId");

            migrationBuilder.CreateIndex(
                name: "IX_KnowledgeComponents_ParentId",
                table: "KnowledgeComponents",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_KnowledgeComponents_KnowledgeComponents_ParentId",
                table: "KnowledgeComponents",
                column: "ParentId",
                principalTable: "KnowledgeComponents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_AssessmentEvents_AssessmentEventId",
                table: "Submissions",
                column: "AssessmentEventId",
                principalTable: "AssessmentEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KnowledgeComponents_KnowledgeComponents_ParentId",
                table: "KnowledgeComponents");

            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_AssessmentEvents_AssessmentEventId",
                table: "Submissions");

            migrationBuilder.DropIndex(
                name: "IX_Submissions_AssessmentEventId",
                table: "Submissions");

            migrationBuilder.DropIndex(
                name: "IX_KnowledgeComponents_ParentId",
                table: "KnowledgeComponents");

            migrationBuilder.DropColumn(
                name: "CorrectnessLevel",
                table: "Submissions");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "KnowledgeComponents");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeStamp",
                table: "Submissions",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }
    }
}
