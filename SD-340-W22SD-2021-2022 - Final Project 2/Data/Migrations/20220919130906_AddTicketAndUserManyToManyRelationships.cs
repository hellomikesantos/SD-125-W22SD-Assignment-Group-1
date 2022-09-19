using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SD_340_W22SD_2021_2022___Final_Project_2.Data.Migrations
{
    public partial class AddTicketAndUserManyToManyRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUserTicket1",
                columns: table => new
                {
                    OwnedTicketsId = table.Column<int>(type: "int", nullable: false),
                    TaskOwnersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserTicket1", x => new { x.OwnedTicketsId, x.TaskOwnersId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserTicket1_AspNetUsers_TaskOwnersId",
                        column: x => x.TaskOwnersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserTicket1_Ticket_OwnedTicketsId",
                        column: x => x.OwnedTicketsId,
                        principalTable: "Ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserTicket2",
                columns: table => new
                {
                    TaskWatchersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WatchedTicketsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserTicket2", x => new { x.TaskWatchersId, x.WatchedTicketsId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserTicket2_AspNetUsers_TaskWatchersId",
                        column: x => x.TaskWatchersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserTicket2_Ticket_WatchedTicketsId",
                        column: x => x.WatchedTicketsId,
                        principalTable: "Ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserTicket1_TaskOwnersId",
                table: "ApplicationUserTicket1",
                column: "TaskOwnersId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserTicket2_WatchedTicketsId",
                table: "ApplicationUserTicket2",
                column: "WatchedTicketsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserTicket1");

            migrationBuilder.DropTable(
                name: "ApplicationUserTicket2");
        }
    }
}
