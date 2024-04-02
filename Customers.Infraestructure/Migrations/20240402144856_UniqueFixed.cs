using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Customers.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class UniqueFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_IdentificationNumber",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_Email",
                table: "Contacts");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeletedToken",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DeletedToken",
                table: "Contacts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Customers_IdentificationNumber_DeletedToken",
                table: "Customers",
                columns: new[] { "IdentificationNumber", "DeletedToken" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Contacts_Email_DeletedToken",
                table: "Contacts",
                columns: new[] { "Email", "DeletedToken" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Customers_IdentificationNumber_DeletedToken",
                table: "Customers");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Contacts_Email_DeletedToken",
                table: "Contacts");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeletedToken",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeletedToken",
                table: "Contacts",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_IdentificationNumber",
                table: "Customers",
                column: "IdentificationNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_Email",
                table: "Contacts",
                column: "Email",
                unique: true);
        }
    }
}
