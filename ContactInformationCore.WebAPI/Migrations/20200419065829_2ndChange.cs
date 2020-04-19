using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactInformationCore.WebAPI.Migrations
{
    public partial class _2ndChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Contacts",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Contacts",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
