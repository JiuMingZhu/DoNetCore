using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace 扫码改需求.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequireModelItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConfirmStatus = table.Column<int>(nullable: false),
                    ContactPerson = table.Column<string>(nullable: true),
                    ContactTel = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    LastestDate = table.Column<DateTime>(nullable: false),
                    OriDate = table.Column<DateTime>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    WorkingStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequireModelItems", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequireModelItems");
        }
    }
}
