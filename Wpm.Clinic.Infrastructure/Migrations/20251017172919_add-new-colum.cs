using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wpm.Clinic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addnewcolum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Consultations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "Consultations");
        }
    }
}
