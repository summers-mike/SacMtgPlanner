using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SacMtgPlanner.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meeting",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Benediction = table.Column<string>(nullable: true),
                    ClosingHymnName = table.Column<string>(nullable: true),
                    ClosingHymnNumber = table.Column<decimal>(nullable: false),
                    Conductor = table.Column<string>(nullable: true),
                    Invocation = table.Column<string>(nullable: true),
                    MeetingDate = table.Column<DateTime>(nullable: false),
                    OpeningHymnName = table.Column<string>(nullable: true),
                    OpeningHymnNumber = table.Column<decimal>(nullable: false),
                    SacHymnName = table.Column<string>(nullable: true),
                    SacHymnNumber = table.Column<decimal>(nullable: false),
                    SpeakerOne = table.Column<string>(nullable: true),
                    SpeakerTwo = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    YouthSpeaker = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meeting", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meeting");
        }
    }
}
