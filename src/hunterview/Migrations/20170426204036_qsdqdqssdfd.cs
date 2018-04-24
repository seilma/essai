using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Domain;

namespace hunterview.Migrations
{
    public partial class qsdqdqssdfd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Jobs");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Degree",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: Degree.bachelor);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Salary",
                table: "Jobs",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "WorkHours",
                table: "Jobs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Degree",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Details",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "WorkHours",
                table: "Jobs");

            migrationBuilder.AddColumn<double>(
                name: "Duration",
                table: "Jobs",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
