using Microsoft.EntityFrameworkCore.Migrations;

namespace vehicles.API.Migrations
{
    public partial class AddTableProceduresIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_procedures_Description",
                table: "procedures",
                column: "Description",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_procedures_Description",
                table: "procedures");
        }
    }
}
