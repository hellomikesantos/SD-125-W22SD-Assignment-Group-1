using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SD_340_W22SD_2021_2022___Final_Project_2.Data.Migrations
{
    public partial class RenameTaskToProjectTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Task_TaskId",
                table: "Comment");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.RenameColumn(
                name: "TaskId",
                table: "Comment",
                newName: "ProjectTaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_TaskId",
                table: "Comment",
                newName: "IX_Comment_ProjectTaskId");

            migrationBuilder.CreateTable(
                name: "ProjectTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectTask_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTask_ProjectId",
                table: "ProjectTask",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_ProjectTask_ProjectTaskId",
                table: "Comment",
                column: "ProjectTaskId",
                principalTable: "ProjectTask",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_ProjectTask_ProjectTaskId",
                table: "Comment");

            migrationBuilder.DropTable(
                name: "ProjectTask");

            migrationBuilder.RenameColumn(
                name: "ProjectTaskId",
                table: "Comment",
                newName: "TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_ProjectTaskId",
                table: "Comment",
                newName: "IX_Comment_TaskId");

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Task_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Task_ProjectId",
                table: "Task",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Task_TaskId",
                table: "Comment",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
