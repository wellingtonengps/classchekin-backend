using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace class_checkin.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentAndAttendance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "title",
                table: "Sessions",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "duration",
                table: "Sessions",
                newName: "Duration");

            migrationBuilder.RenameColumn(
                name: "createdAt",
                table: "Sessions",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Sessions",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    StudentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SessionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendances_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendances_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_SessionId",
                table: "Attendances",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_StudentId",
                table: "Attendances",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Sessions",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Sessions",
                newName: "duration");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Sessions",
                newName: "createdAt");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Sessions",
                newName: "id");
        }
    }
}
