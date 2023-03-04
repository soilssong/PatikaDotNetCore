using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SecondCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppRoleId",
                table: "AppCustomers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AppRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Definition = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRole", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppCustomers_AppRoleId",
                table: "AppCustomers",
                column: "AppRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppCustomers_AppRole_AppRoleId",
                table: "AppCustomers",
                column: "AppRoleId",
                principalTable: "AppRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppCustomers_AppRole_AppRoleId",
                table: "AppCustomers");

            migrationBuilder.DropTable(
                name: "AppRole");

            migrationBuilder.DropIndex(
                name: "IX_AppCustomers_AppRoleId",
                table: "AppCustomers");

            migrationBuilder.DropColumn(
                name: "AppRoleId",
                table: "AppCustomers");
        }
    }
}
