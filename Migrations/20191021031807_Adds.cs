using Microsoft.EntityFrameworkCore.Migrations;

namespace footprints.Migrations
{
    public partial class Adds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_House_Users_UserId",
                table: "House");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Users_UserId",
                table: "Vehicle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_House",
                table: "House");

            migrationBuilder.RenameTable(
                name: "Vehicle",
                newName: "Vehicles");

            migrationBuilder.RenameTable(
                name: "House",
                newName: "Houses");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_UserId",
                table: "Vehicles",
                newName: "IX_Vehicles_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_House_UserId",
                table: "Houses",
                newName: "IX_Houses_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Houses",
                table: "Houses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_Users_UserId",
                table: "Houses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Users_UserId",
                table: "Vehicles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Houses_Users_UserId",
                table: "Houses");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Users_UserId",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Houses",
                table: "Houses");

            migrationBuilder.RenameTable(
                name: "Vehicles",
                newName: "Vehicle");

            migrationBuilder.RenameTable(
                name: "Houses",
                newName: "House");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_UserId",
                table: "Vehicle",
                newName: "IX_Vehicle_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Houses_UserId",
                table: "House",
                newName: "IX_House_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_House",
                table: "House",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_House_Users_UserId",
                table: "House",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Users_UserId",
                table: "Vehicle",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
