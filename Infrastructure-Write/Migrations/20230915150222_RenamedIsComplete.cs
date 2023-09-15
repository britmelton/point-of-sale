using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Write.Migrations
{
    /// <inheritdoc />
    public partial class RenamedIsComplete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsCompleted",
                table: "Order",
                newName: "IsComplete");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsComplete",
                table: "Order",
                newName: "IsCompleted");
        }
    }
}
