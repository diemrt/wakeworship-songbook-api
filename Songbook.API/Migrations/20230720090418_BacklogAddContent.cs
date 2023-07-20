using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Songbook.API.Migrations
{
    /// <inheritdoc />
    public partial class BacklogAddContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "content",
                schema: "dbo",
                table: "song",
                type: "nvarchar(MAX)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "content",
                schema: "dbo",
                table: "song");
        }
    }
}
