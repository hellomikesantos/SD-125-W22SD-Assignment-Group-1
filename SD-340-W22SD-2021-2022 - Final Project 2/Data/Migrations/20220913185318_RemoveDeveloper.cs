using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SD_340_W22SD_2021_2022___Final_Project_2.Data.Migrations
{
    public partial class RemoveDeveloper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeveloperProject");

            migrationBuilder.DropTable(
                name: "DeveloperProjectTask");

            migrationBuilder.DropTable(
                name: "Developer");

            migrationBuilder.AddColumn<string>(
                name: "ProjectManagerId",
                table: "Project",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectTaskId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Project_ProjectManagerId",
                table: "Project",
                column: "ProjectManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProjectId",
                table: "AspNetUsers",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProjectTaskId",
                table: "AspNetUsers",
                column: "ProjectTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Project_ProjectId",
                table: "AspNetUsers",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ProjectTask_ProjectTaskId",
                table: "AspNetUsers",
                column: "ProjectTaskId",
                principalTable: "ProjectTask",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_AspNetUsers_ProjectManagerId",
                table: "Project",
                column: "ProjectManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Project_ProjectId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ProjectTask_ProjectTaskId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_AspNetUsers_ProjectManagerId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_ProjectManagerId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProjectId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProjectTaskId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProjectManagerId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProjectTaskId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Developer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperProject",
                columns: table => new
                {
                    DeveloperId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperProject", x => new { x.DeveloperId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_DeveloperProject_Developer_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeveloperProject_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperProjectTask",
                columns: table => new
                {
                    DeveloperId = table.Column<int>(type: "int", nullable: false),
                    ProjectTaskId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperProjectTask", x => new { x.DeveloperId, x.ProjectTaskId });
                    table.ForeignKey(
                        name: "FK_DeveloperProjectTask_Developer_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeveloperProjectTask_ProjectTask_ProjectTaskId",
                        column: x => x.ProjectTaskId,
                        principalTable: "ProjectTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperProject_ProjectId",
                table: "DeveloperProject",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperProjectTask_ProjectTaskId",
                table: "DeveloperProjectTask",
                column: "ProjectTaskId");
        }
    }
}
