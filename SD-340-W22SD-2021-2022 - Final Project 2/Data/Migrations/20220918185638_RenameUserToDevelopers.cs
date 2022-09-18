using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SD_340_W22SD_2021_2022___Final_Project_2.Data.Migrations
{
    public partial class RenameUserToDevelopers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserProject_AspNetUsers_UserId",
                table: "ApplicationUserProject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserProject",
                table: "ApplicationUserProject");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUserProject_UserId",
                table: "ApplicationUserProject");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ApplicationUserProject",
                newName: "DevelopersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserProject",
                table: "ApplicationUserProject",
                columns: new[] { "DevelopersId", "ProjectsId" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserProject_ProjectsId",
                table: "ApplicationUserProject",
                column: "ProjectsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserProject_AspNetUsers_DevelopersId",
                table: "ApplicationUserProject",
                column: "DevelopersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserProject_AspNetUsers_DevelopersId",
                table: "ApplicationUserProject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserProject",
                table: "ApplicationUserProject");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUserProject_ProjectsId",
                table: "ApplicationUserProject");

            migrationBuilder.RenameColumn(
                name: "DevelopersId",
                table: "ApplicationUserProject",
                newName: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserProject",
                table: "ApplicationUserProject",
                columns: new[] { "ProjectsId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserProject_UserId",
                table: "ApplicationUserProject",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserProject_AspNetUsers_UserId",
                table: "ApplicationUserProject",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
