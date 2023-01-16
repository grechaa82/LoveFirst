using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoveFirst.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    ProfileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.ProfileId);
                });

            migrationBuilder.CreateTable(
                name: "Counters",
                columns: table => new
                {
                    CounterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    TotalScores = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counters", x => x.CounterId);
                    table.ForeignKey(
                        name: "FK_Counters_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    OperationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CounterId = table.Column<int>(type: "int", nullable: false),
                    ParticipantId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    DateOperation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.OperationId);
                    table.ForeignKey(
                        name: "FK_Operations_Counters_CounterId",
                        column: x => x.CounterId,
                        principalTable: "Counters",
                        principalColumn: "CounterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    ParticipantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CounterId = table.Column<int>(type: "int", nullable: false),
                    NameParticipant = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    NumberScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.ParticipantId);
                    table.ForeignKey(
                        name: "FK_Participants_Counters_CounterId",
                        column: x => x.CounterId,
                        principalTable: "Counters",
                        principalColumn: "CounterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "Login", "PasswordHash" },
                values: new object[] { 1, "test", "9f86d081884c7d659a2feaa0c55ad015a3bf4f1b2b0b822cd15d6c15b0f00a08" });

            migrationBuilder.InsertData(
                table: "Counters",
                columns: new[] { "CounterId", "ProfileId", "TotalScores" },
                values: new object[] { 1, 1, 3 });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "OperationId", "CounterId", "DateOperation", "ParticipantId", "Score" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 10, 11, 21, 11, 27, 601, DateTimeKind.Local).AddTicks(5238), 1, 1 },
                    { 2, 1, new DateTime(2022, 10, 11, 21, 11, 27, 602, DateTimeKind.Local).AddTicks(4817), 2, 1 },
                    { 3, 1, new DateTime(2022, 10, 11, 21, 11, 27, 602, DateTimeKind.Local).AddTicks(4864), 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Participants",
                columns: new[] { "ParticipantId", "CounterId", "NameParticipant", "NumberScore" },
                values: new object[,]
                {
                    { 1, 1, "Danila", 2 },
                    { 2, 1, "An", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Counters_ProfileId",
                table: "Counters",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_CounterId",
                table: "Operations",
                column: "CounterId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_CounterId",
                table: "Participants",
                column: "CounterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "Counters");

            migrationBuilder.DropTable(
                name: "Profiles");
        }
    }
}
