using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM1.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhobeNumber",
                table: "CRMs",
                newName: "PhoneNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "CRMs",
                newName: "PhobeNumber");
        }
    }
}
