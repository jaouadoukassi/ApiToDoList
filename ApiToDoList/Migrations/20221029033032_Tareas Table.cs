using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiToDoList.Migrations
{
    public partial class TareasTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TasksTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateTasks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAtTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTasks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpDateAtTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteTasks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAtTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasksTable", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TasksTable");
        }
    }
}
