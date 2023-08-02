using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Songbook.API.Migrations
{
    /// <inheritdoc />
    public partial class BacklogAddUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    enabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    insert_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    uid = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    username = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user",
                schema: "dbo");
        }
    }
}
