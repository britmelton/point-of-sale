using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Write.Migrations
{
    /// <inheritdoc />
    public partial class AddedCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartLineItem_Cart_CartId",
                table: "CartLineItem");

            migrationBuilder.AlterColumn<Guid>(
                name: "CartId",
                table: "CartLineItem",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CartLineItem_Cart_CartId",
                table: "CartLineItem",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartLineItem_Cart_CartId",
                table: "CartLineItem");

            migrationBuilder.AlterColumn<Guid>(
                name: "CartId",
                table: "CartLineItem",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_CartLineItem_Cart_CartId",
                table: "CartLineItem",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id");
        }
    }
}
