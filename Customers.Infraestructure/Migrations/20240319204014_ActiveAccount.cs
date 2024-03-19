using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Customers.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class ActiveAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsClient",
                table: "Customers",
                newName: "ActiveAccount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ActiveAccount",
                table: "Customers",
                newName: "IsClient");
        }
    }
}
