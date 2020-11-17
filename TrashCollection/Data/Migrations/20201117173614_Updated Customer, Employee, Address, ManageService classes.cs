using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollection.Data.Migrations
{
    public partial class UpdatedCustomerEmployeeAddressManageServiceclasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0999b6be-8165-4d6d-98ba-35f932565168");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "03b4fb97-f81e-4271-9730-6869357007df", "95561291-4869-4a51-b5eb-b55010cd0e74", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03b4fb97-f81e-4271-9730-6869357007df");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0999b6be-8165-4d6d-98ba-35f932565168", "9ea9630c-a9be-4491-a61b-550bafd0c9ac", "Admin", "ADMIN" });
        }
    }
}
