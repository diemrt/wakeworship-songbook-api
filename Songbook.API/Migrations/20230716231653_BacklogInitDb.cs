using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Songbook.API.Migrations
{
    /// <inheritdoc />
    public partial class BacklogInitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "chord_type",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    display_name = table.Column<string>(type: "nvarchar(182)", maxLength: 182, nullable: false),
                    insert_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chord_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "song_block_type",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    display_name = table.Column<string>(type: "nvarchar(182)", maxLength: 182, nullable: false),
                    insert_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_song_block_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "song",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    key = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    capo = table.Column<int>(type: "int", nullable: true),
                    insert_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_song", x => x.id);
                    table.ForeignKey(
                        name: "FK_song_chord_type_key",
                        column: x => x.key,
                        principalSchema: "dbo",
                        principalTable: "chord_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "song_block",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    song_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    song_block_type_id = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    position_in_song = table.Column<int>(type: "int", nullable: false),
                    insert_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_song_block", x => x.id);
                    table.ForeignKey(
                        name: "FK_song_block_song_block_type_song_block_type_id",
                        column: x => x.song_block_type_id,
                        principalSchema: "dbo",
                        principalTable: "song_block_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_song_block_song_song_id",
                        column: x => x.song_id,
                        principalSchema: "dbo",
                        principalTable: "song",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "song_row",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    insert_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    song_block_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    position_in_block = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_song_row", x => x.id);
                    table.ForeignKey(
                        name: "FK_song_row_song_block_song_block_id",
                        column: x => x.song_block_id,
                        principalSchema: "dbo",
                        principalTable: "song_block",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "phrase_chord",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    song_row_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    chord_type_id = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    phrase = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    position_in_row = table.Column<int>(type: "int", nullable: false),
                    insert_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phrase_chord", x => x.id);
                    table.ForeignKey(
                        name: "FK_phrase_chord_chord_type_chord_type_id",
                        column: x => x.chord_type_id,
                        principalSchema: "dbo",
                        principalTable: "chord_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_phrase_chord_song_row_song_row_id",
                        column: x => x.song_row_id,
                        principalSchema: "dbo",
                        principalTable: "song_row",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_phrase_chord_chord_type_id",
                schema: "dbo",
                table: "phrase_chord",
                column: "chord_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_phrase_chord_song_row_id",
                schema: "dbo",
                table: "phrase_chord",
                column: "song_row_id");

            migrationBuilder.CreateIndex(
                name: "IX_song_key",
                schema: "dbo",
                table: "song",
                column: "key");

            migrationBuilder.CreateIndex(
                name: "IX_song_block_song_block_type_id",
                schema: "dbo",
                table: "song_block",
                column: "song_block_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_song_block_song_id",
                schema: "dbo",
                table: "song_block",
                column: "song_id");

            migrationBuilder.CreateIndex(
                name: "IX_song_row_song_block_id",
                schema: "dbo",
                table: "song_row",
                column: "song_block_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "phrase_chord",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "song_row",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "song_block",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "song_block_type",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "song",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "chord_type",
                schema: "dbo");
        }
    }
}
