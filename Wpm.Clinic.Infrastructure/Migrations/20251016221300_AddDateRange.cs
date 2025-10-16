using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wpm.Clinic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDateRange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EndedAt",
                table: "Consultations",
                newName: "When_EndedAt");

            migrationBuilder.RenameColumn(
                name: "StartAt",
                table: "Consultations",
                newName: "When_StartedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "When_EndedAt",
                table: "Consultations",
                newName: "EndedAt");

            migrationBuilder.RenameColumn(
                name: "When_StartedAt",
                table: "Consultations",
                newName: "StartAt");
        }
    }
}
