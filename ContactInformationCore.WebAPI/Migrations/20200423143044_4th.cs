using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactInformationCore.WebAPI.Migrations
{
    public partial class _4th : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contacts_Id_First_Name_Last_Name_Email_Phone_Number_Status",
                table: "Contacts");

            migrationBuilder.AlterColumn<string>(
                name: "Last_Name",
                table: "Contacts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "First_Name",
                table: "Contacts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Contacts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Contacts_Phone_Number",
                table: "Contacts",
                column: "Phone_Number");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Contacts_Phone_Number",
                table: "Contacts");

            migrationBuilder.AlterColumn<string>(
                name: "Last_Name",
                table: "Contacts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "First_Name",
                table: "Contacts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Contacts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_Id_First_Name_Last_Name_Email_Phone_Number_Status",
                table: "Contacts",
                columns: new[] { "Id", "First_Name", "Last_Name", "Email", "Phone_Number", "Status" },
                unique: true);
        }
    }
}
