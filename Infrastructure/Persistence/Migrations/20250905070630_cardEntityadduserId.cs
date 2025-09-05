using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class cardEntityadduserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "bankingApi",
                table: "Cards",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Cards_UserId",
                schema: "bankingApi",
                table: "Cards",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_AspNetUsers_UserId",
                schema: "bankingApi",
                table: "Cards",
                column: "UserId",
                principalSchema: "bankingApi",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_AspNetUsers_UserId",
                schema: "bankingApi",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_UserId",
                schema: "bankingApi",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "bankingApi",
                table: "Cards");
        }
    }
}
