using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComputerShopApi.Migrations
{
    /// <inheritdoc />
    public partial class AddUpdatedFiledFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedTiem",
                table: "computers",
                newName: "UpdatedTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "computers",
                newName: "UpdatedTiem");
        }
    }
}
