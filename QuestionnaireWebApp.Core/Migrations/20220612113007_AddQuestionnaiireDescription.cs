using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestinaryWebApp.Core.Migrations
{
    public partial class AddQuestionnaiireDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Questionnairees",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Questionnairees");
        }
    }
}
