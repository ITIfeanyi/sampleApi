using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sampleApi.Migrations
{
    /// <inheritdoc />
    public partial class fixtablename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailName",
                table: "Users",
                newName: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "EmailName");
        }
    }
}
