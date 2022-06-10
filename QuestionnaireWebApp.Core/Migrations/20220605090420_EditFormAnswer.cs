using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestinaryWebApp.Core.Migrations
{
    public partial class EditFormAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormAnswers_Answers_AnswerId",
                table: "FormAnswers");

            migrationBuilder.AlterColumn<int>(
                name: "AnswerId",
                table: "FormAnswers",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "OurAnswer",
                table: "FormAnswers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "FormAnswers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FormAnswers_QuestionId",
                table: "FormAnswers",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormAnswers_Answers_AnswerId",
                table: "FormAnswers",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FormAnswers_Questions_QuestionId",
                table: "FormAnswers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormAnswers_Answers_AnswerId",
                table: "FormAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_FormAnswers_Questions_QuestionId",
                table: "FormAnswers");

            migrationBuilder.DropIndex(
                name: "IX_FormAnswers_QuestionId",
                table: "FormAnswers");

            migrationBuilder.DropColumn(
                name: "OurAnswer",
                table: "FormAnswers");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "FormAnswers");

            migrationBuilder.AlterColumn<int>(
                name: "AnswerId",
                table: "FormAnswers",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FormAnswers_Answers_AnswerId",
                table: "FormAnswers",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
