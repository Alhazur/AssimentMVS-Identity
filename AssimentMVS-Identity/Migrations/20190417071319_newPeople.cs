using Microsoft.EntityFrameworkCore.Migrations;

namespace AssimentMVS_Identity.Migrations
{
    public partial class newPeople : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "People",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_CountryId",
                table: "People",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Countries_CountryId",
                table: "People",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Countries_CountryId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_CountryId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "People");
        }
    }
}
