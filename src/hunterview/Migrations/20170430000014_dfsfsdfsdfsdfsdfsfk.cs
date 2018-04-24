using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace hunterview.Migrations
{
    public partial class dfsfsdfsdfsdfsdfsfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorite_AspNetUsers_UserId1",
                table: "Favorite");

            migrationBuilder.DropIndex(
                name: "IX_Favorite_UserId1",
                table: "Favorite");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Favorite");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Favorite",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Favorite_UserId",
                table: "Favorite",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorite_AspNetUsers_UserId",
                table: "Favorite",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorite_AspNetUsers_UserId",
                table: "Favorite");

            migrationBuilder.DropIndex(
                name: "IX_Favorite_UserId",
                table: "Favorite");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Favorite",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Favorite",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Favorite_UserId1",
                table: "Favorite",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorite_AspNetUsers_UserId1",
                table: "Favorite",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
