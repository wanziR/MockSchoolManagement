using Microsoft.EntityFrameworkCore.Migrations;

namespace MockSchoolManagement.Migrations
{
    public partial class UpdateSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "Major", "Name", "PhotoPath" },
                values: new object[] { 3, "ls@5amcn.com", 2, "李四", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "Major", "Name", "PhotoPath" },
                values: new object[] { 4, "ww@5amcn.com", 2, "王五", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
