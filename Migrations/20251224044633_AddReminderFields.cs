using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyTaskReminderSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddReminderFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReminderActive",
                table: "TaskModels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ReminderTime",
                table: "TaskModels",
                type: "time",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReminderActive",
                table: "TaskModels");

            migrationBuilder.DropColumn(
                name: "ReminderTime",
                table: "TaskModels");
        }
    }
}
