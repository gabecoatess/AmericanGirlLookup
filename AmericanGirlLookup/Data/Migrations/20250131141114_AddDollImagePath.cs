﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmericanGirlLookup.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDollImagePath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Doll",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Doll");
        }
    }
}
