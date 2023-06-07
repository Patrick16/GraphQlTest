using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class navprop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Property_PropertyId",
                table: "Payment");

            migrationBuilder.AlterColumn<int>(
                name: "PropertyId",
                table: "Payment",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Property_PropertyId",
                table: "Payment",
                column: "PropertyId",
                principalTable: "Property",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Property_PropertyId",
                table: "Payment");

            migrationBuilder.AlterColumn<int>(
                name: "PropertyId",
                table: "Payment",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Property_PropertyId",
                table: "Payment",
                column: "PropertyId",
                principalTable: "Property",
                principalColumn: "Id");
        }
    }
}
