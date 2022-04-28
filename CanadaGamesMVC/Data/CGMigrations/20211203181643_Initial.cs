using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CanadaGamesMVC.Data.CGMigrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CG");

            migrationBuilder.CreateTable(
                name: "Coaches",
                schema: "CG",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coaches", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Contingents",
                schema: "CG",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(maxLength: 2, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contingents", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                schema: "CG",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(maxLength: 1, nullable: false),
                    Name = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sports",
                schema: "CG",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(maxLength: 3, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Hometowns",
                schema: "CG",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    ContingentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hometowns", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Hometowns_Contingents_ContingentID",
                        column: x => x.ContingentID,
                        principalSchema: "CG",
                        principalTable: "Contingents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                schema: "CG",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Type = table.Column<string>(maxLength: 10, nullable: false),
                    SportID = table.Column<int>(nullable: false),
                    GenderID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Events_Genders_GenderID",
                        column: x => x.GenderID,
                        principalSchema: "CG",
                        principalTable: "Genders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Sports_SportID",
                        column: x => x.SportID,
                        principalSchema: "CG",
                        principalTable: "Sports",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Athletes",
                schema: "CG",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AthleteCode = table.Column<string>(maxLength: 7, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    DOB = table.Column<DateTime>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    YearsInSport = table.Column<int>(nullable: false),
                    Affiliation = table.Column<string>(maxLength: 255, nullable: false),
                    Goals = table.Column<string>(maxLength: 255, nullable: false),
                    Position = table.Column<string>(maxLength: 50, nullable: true),
                    RoleModel = table.Column<string>(maxLength: 100, nullable: true),
                    MediaInfo = table.Column<string>(maxLength: 2000, nullable: false),
                    ContingentID = table.Column<int>(nullable: false),
                    SportID = table.Column<int>(nullable: false),
                    GenderID = table.Column<int>(nullable: false),
                    CoachID = table.Column<int>(nullable: true),
                    HometownID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Athletes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Athletes_Coaches_CoachID",
                        column: x => x.CoachID,
                        principalSchema: "CG",
                        principalTable: "Coaches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Athletes_Contingents_ContingentID",
                        column: x => x.ContingentID,
                        principalSchema: "CG",
                        principalTable: "Contingents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Athletes_Genders_GenderID",
                        column: x => x.GenderID,
                        principalSchema: "CG",
                        principalTable: "Genders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Athletes_Hometowns_HometownID",
                        column: x => x.HometownID,
                        principalSchema: "CG",
                        principalTable: "Hometowns",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Athletes_Sports_SportID",
                        column: x => x.SportID,
                        principalSchema: "CG",
                        principalTable: "Sports",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AthletePhotos",
                schema: "CG",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<byte[]>(nullable: true),
                    MimeType = table.Column<string>(maxLength: 255, nullable: true),
                    AthleteID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AthletePhotos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AthletePhotos_Athletes_AthleteID",
                        column: x => x.AthleteID,
                        principalSchema: "CG",
                        principalTable: "Athletes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AthleteSports",
                schema: "CG",
                columns: table => new
                {
                    SportID = table.Column<int>(nullable: false),
                    AthleteID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AthleteSports", x => new { x.SportID, x.AthleteID });
                    table.ForeignKey(
                        name: "FK_AthleteSports_Athletes_AthleteID",
                        column: x => x.AthleteID,
                        principalSchema: "CG",
                        principalTable: "Athletes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AthleteSports_Sports_SportID",
                        column: x => x.SportID,
                        principalSchema: "CG",
                        principalTable: "Sports",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AthleteThumbnails",
                schema: "CG",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<byte[]>(nullable: true),
                    MimeType = table.Column<string>(maxLength: 255, nullable: true),
                    AthleteID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AthleteThumbnails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AthleteThumbnails_Athletes_AthleteID",
                        column: x => x.AthleteID,
                        principalSchema: "CG",
                        principalTable: "Athletes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Placements",
                schema: "CG",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Place = table.Column<int>(nullable: false),
                    Comments = table.Column<string>(maxLength: 2000, nullable: true),
                    EventID = table.Column<int>(nullable: false),
                    AthleteID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Placements", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Placements_Athletes_AthleteID",
                        column: x => x.AthleteID,
                        principalSchema: "CG",
                        principalTable: "Athletes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Placements_Events_EventID",
                        column: x => x.EventID,
                        principalSchema: "CG",
                        principalTable: "Events",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UploadedFiles",
                schema: "CG",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FileName = table.Column<string>(maxLength: 255, nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    AthleteID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadedFiles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UploadedFiles_Athletes_AthleteID",
                        column: x => x.AthleteID,
                        principalSchema: "CG",
                        principalTable: "Athletes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FileContent",
                schema: "CG",
                columns: table => new
                {
                    FileContentID = table.Column<int>(nullable: false),
                    Content = table.Column<byte[]>(nullable: true),
                    MimeType = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileContent", x => x.FileContentID);
                    table.ForeignKey(
                        name: "FK_FileContent_UploadedFiles_FileContentID",
                        column: x => x.FileContentID,
                        principalSchema: "CG",
                        principalTable: "UploadedFiles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AthletePhotos_AthleteID",
                schema: "CG",
                table: "AthletePhotos",
                column: "AthleteID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Athletes_AthleteCode",
                schema: "CG",
                table: "Athletes",
                column: "AthleteCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Athletes_CoachID",
                schema: "CG",
                table: "Athletes",
                column: "CoachID");

            migrationBuilder.CreateIndex(
                name: "IX_Athletes_ContingentID",
                schema: "CG",
                table: "Athletes",
                column: "ContingentID");

            migrationBuilder.CreateIndex(
                name: "IX_Athletes_GenderID",
                schema: "CG",
                table: "Athletes",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_Athletes_HometownID",
                schema: "CG",
                table: "Athletes",
                column: "HometownID");

            migrationBuilder.CreateIndex(
                name: "IX_Athletes_SportID",
                schema: "CG",
                table: "Athletes",
                column: "SportID");

            migrationBuilder.CreateIndex(
                name: "IX_AthleteSports_AthleteID",
                schema: "CG",
                table: "AthleteSports",
                column: "AthleteID");

            migrationBuilder.CreateIndex(
                name: "IX_AthleteThumbnails_AthleteID",
                schema: "CG",
                table: "AthleteThumbnails",
                column: "AthleteID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_GenderID",
                schema: "CG",
                table: "Events",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_Events_SportID",
                schema: "CG",
                table: "Events",
                column: "SportID");

            migrationBuilder.CreateIndex(
                name: "IX_Hometowns_ContingentID",
                schema: "CG",
                table: "Hometowns",
                column: "ContingentID");

            migrationBuilder.CreateIndex(
                name: "IX_Hometowns_ID",
                schema: "CG",
                table: "Hometowns",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Placements_EventID",
                schema: "CG",
                table: "Placements",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Placements_AthleteID_EventID",
                schema: "CG",
                table: "Placements",
                columns: new[] { "AthleteID", "EventID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UploadedFiles_AthleteID",
                schema: "CG",
                table: "UploadedFiles",
                column: "AthleteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AthletePhotos",
                schema: "CG");

            migrationBuilder.DropTable(
                name: "AthleteSports",
                schema: "CG");

            migrationBuilder.DropTable(
                name: "AthleteThumbnails",
                schema: "CG");

            migrationBuilder.DropTable(
                name: "FileContent",
                schema: "CG");

            migrationBuilder.DropTable(
                name: "Placements",
                schema: "CG");

            migrationBuilder.DropTable(
                name: "UploadedFiles",
                schema: "CG");

            migrationBuilder.DropTable(
                name: "Events",
                schema: "CG");

            migrationBuilder.DropTable(
                name: "Athletes",
                schema: "CG");

            migrationBuilder.DropTable(
                name: "Coaches",
                schema: "CG");

            migrationBuilder.DropTable(
                name: "Genders",
                schema: "CG");

            migrationBuilder.DropTable(
                name: "Hometowns",
                schema: "CG");

            migrationBuilder.DropTable(
                name: "Sports",
                schema: "CG");

            migrationBuilder.DropTable(
                name: "Contingents",
                schema: "CG");
        }
    }
}
