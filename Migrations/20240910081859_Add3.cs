﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMSWEBAPI.Migrations
{
    /// <inheritdoc />
    public partial class Add3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Salary",
                table: "Teachers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Teachers");
        }
    }
}
