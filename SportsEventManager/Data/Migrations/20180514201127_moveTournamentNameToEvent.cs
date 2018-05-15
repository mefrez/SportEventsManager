using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SportsEventManager.Data.Migrations
{
    public partial class moveTournamentNameToEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TournamentName",
                table: "VolleyballDbSet");

            migrationBuilder.DropColumn(
                name: "TournamentName",
                table: "TennisDbSet");

            migrationBuilder.DropColumn(
                name: "TournamentName",
                table: "FootballDbSet");

            migrationBuilder.AddColumn<string>(
                name: "TournamentName",
                table: "EventDbSet",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TournamentName",
                table: "EventDbSet");

            migrationBuilder.AddColumn<string>(
                name: "TournamentName",
                table: "VolleyballDbSet",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TournamentName",
                table: "TennisDbSet",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TournamentName",
                table: "FootballDbSet",
                nullable: true);
        }
    }
}
